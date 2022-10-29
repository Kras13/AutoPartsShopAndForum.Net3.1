namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Services.Web.Mail;
    using Microsoft.AspNetCore.Mvc;

    using MailSender.SMTP_MailKit;

    public class MailsController : Controller
    {
        private readonly IMailService mailService;

        public MailsController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        public IActionResult Send()
        {
            MailSender.SendEmail("Demo");

            return Ok();
        }
    }
}
