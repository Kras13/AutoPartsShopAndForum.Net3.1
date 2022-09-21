namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Services.Data.Mail;
    using AutoPartsShopAndForum.Services.Web.Mail;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MailsController : Controller
    {
        private readonly IMailService mailService;

        public MailsController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        [Authorize]
        public IActionResult Send()
        {
            MailSendInpuModel model = new MailSendInpuModel()
            {
                Sellers = mailService.GetAvailableSellers()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Send(MailSendInpuModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Redirect("Home");
        }
    }
}
