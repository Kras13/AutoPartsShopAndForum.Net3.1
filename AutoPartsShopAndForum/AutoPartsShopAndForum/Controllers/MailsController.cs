namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Services.Web.Mail;
    using Microsoft.AspNetCore.Mvc;


    public class MailsController : Controller
    {
        private readonly IЕMailService mailService;

        public MailsController(IЕMailService mailService)
        {
            this.mailService = mailService;
        }


        public IActionResult Send()
        {
            return Ok();
        }
    }
}
