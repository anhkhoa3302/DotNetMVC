using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using VNPayment;

namespace DotNetMVC.Controllers
{
    public class VNPayTestController : Controller
    {
        private readonly IVNPayPayment _vnpay;

        public VNPayTestController(IVNPayPayment vnpay)
        {
            _vnpay = vnpay;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(string OrderId, string Amount)
        {
            var vnpayPaymentRequest = new VnPayRequest
            {
                OrderId = OrderId,
                Amount = Amount,
                OrderInfo = "Order information",
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };
            var vnpayPaymentUrl = _vnpay.CreatePaymentUrl(vnpayPaymentRequest);
            return Redirect(vnpayPaymentUrl);
        }

        public IActionResult PayReturn()
        {
            var request = HttpContext.Request;
            var url = request.GetEncodedUrl();

            if(request.Query.Count > 0)
            {
                var vnpayData = Request.QueryString;
                return Json(vnpayData);
            }


            return Json("Ok");
        }
    }
}
