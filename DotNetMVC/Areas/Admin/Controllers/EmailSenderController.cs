using EmailService;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmailSenderController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailSenderController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SendEmail(string title, string content)
        {
            Message mssg = new Message(new string[] { "anhkhoa3302@gmail.com" },title, content);
            _emailSender.SendEmail(mssg);
            RedirectToAction("Index");
        }
    }
}
