namespace AutoPartsShopAndForum.Areas.Administrator.Controllers
{
    using AutoPartsShopAndForum.Services.Web.User;
    using Microsoft.AspNetCore.Mvc;
    public class SellersController : BaseAdminController
    {
        private readonly IUserService userService;

        public SellersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Pending()
        {
            var pendingUsers = userService.GetPendingUsers();

            return View(pendingUsers);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            return Redirect(nameof(Pending));
        }
    }
}