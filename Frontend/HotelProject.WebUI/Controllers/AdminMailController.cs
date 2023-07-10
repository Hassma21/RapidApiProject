using HotelProject.WebUI.Models.AdminMail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage=new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelAdmin", "bizim mail *********@gmail.com");//we decide which account to send it from.
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);//we decide which account to send it to.
            mimeMessage.To.Add(mailboxAddressTo);

            //TO DO(Develop this section send message to every customer)
            //foreach (var receiverMail in model.ReceiverMail)
            //{
            //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", receiverMail);
            //    mimeMessage.To.Add(mailboxAddressTo);
            //}

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();//SMTP(Simple Mail Transfer Protocol)
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bizim mail *********@gmail.com", "password key");//we can take app password from  our mail
            client.Send(mimeMessage);
            client.Dispose();

            return View();
        }
    }
}
