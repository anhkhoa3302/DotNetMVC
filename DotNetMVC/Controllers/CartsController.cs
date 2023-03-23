using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetMVC.Data;
using DotNetMVC.Models;

namespace DotNetMVC.Controllers
{
    public class CartsController : Controller
    {
        private readonly DotNetDBContext _context;

        public CartsController(DotNetDBContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var dotNetDBContext = _context.Carts.Include(c => c.Pro).ThenInclude(Product => Product.Img).Include(c => c.User);
            return View(await dotNetDBContext.ToListAsync());
        }

        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var pro = await _context.Products.FindAsync(id);
            if (pro == null)
            {
                return NotFound();
            }

            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CateId", pro.CateId);
            ViewData["ImgId"] = new SelectList(_context.Images, "ImgId", "ImgId", pro.ImgId);

            return View(pro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, [Bind("ProId,ProName,CateId,ImgId,ProDescription,ProPrice,ProStock,CreatedDate,UpdatedDate,DeletedDate")] Product pro)
        {
            if (id != pro.ProId)
            {
                return NotFound();
            }

            Cart cart = new Cart();
            cart.CartId = _context.Carts.Max(p => p.CartId) + 1;
            cart.ProId = Int32.Parse(Request.Form["ProId"]);
            cart.CartQuantity = Int32.Parse(Request.Form["CartQuantity"]);
            cart.CartTotle = Int32.Parse(Request.Form["CartQuantity"]) * Convert.ToInt32(pro.ProPrice);
            cart.UserId = "1";
            cart.CreatedDate = DateTime.Now;
            cart.UpdatedDate = DateTime.Now;
            cart.DeletedDate = DateTime.Now;

            if (cart != null)
            {
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Pro)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProId");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,ProId,CartQuantity,CartTotle,UserId,CreatedDate,UpdatedDate,DeletedDate")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProId", cart.ProId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.UserId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProId", cart.ProId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.UserId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,ProId,CartQuantity,CartTotle,UserId,CreatedDate,UpdatedDate,DeletedDate")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProId", cart.ProId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.UserId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Pro)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'DotNetDBContext.Carts'  is null.");
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return (_context.Carts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
