namespace AutoPartsShopAndForum.Areas.Identity.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        public IActionResult Test()
        {
            return this.Content("In Identity Area in Users Controller");
        }
    }
}
