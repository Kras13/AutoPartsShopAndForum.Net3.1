namespace AutoPartsShopAndForum.Areas.Forum.Controllers
{
    using AutoPartsShopAndForum.Services.Web.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseForumController
    {
        private readonly IForumService forumService;

        public HomeController(IForumService forumService)
        {
            this.forumService = forumService;
        }
        public IActionResult Index()
        {
            var caregories = forumService.GetAllCategories();

            return View(caregories);
        }
    }
}
