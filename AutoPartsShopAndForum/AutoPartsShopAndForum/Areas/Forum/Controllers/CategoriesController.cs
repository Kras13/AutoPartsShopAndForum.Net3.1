namespace AutoPartsShopAndForum.Areas.Forum.Controllers
{
    using AutoPartsShopAndForum.Services.Web.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseForumController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            var categories = categoriesService.GetAll();

            return View(categories);
        }
    }
}
