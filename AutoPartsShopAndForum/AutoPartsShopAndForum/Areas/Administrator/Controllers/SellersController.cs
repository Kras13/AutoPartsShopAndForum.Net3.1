namespace AutoPartsShopAndForum.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class SellersController : BaseAdminController
    {
        public IActionResult Pending()
        {
            return View();
        }
    }
}