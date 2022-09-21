namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Areas.Seller.Models.Input;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MailsController : Controller
    {

        [Authorize]
        public IActionResult Send()
        {
            return View();
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
