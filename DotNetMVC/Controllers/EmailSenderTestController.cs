using EmailService;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMVC.Controllers
{
    public class EmailSenderTestController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailSenderTestController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpGet]
        public void Get()
        {


        }
    }
}
