namespace AutoPartsShopAndForum.Areas.Forum.Controllers
{
    using AutoPartsShopAndForum.Areas.Forum.Models;
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Web.Forum;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseForumController
    {
        private readonly IForumService forumService;
        private readonly ICategoriesService categoriesService;

        public PostsController(IForumService forumService, ICategoriesService categoriesService)
        {
            this.forumService = forumService;
            this.categoriesService = categoriesService;
        }

        public IActionResult ByCategoryId(int categoryId)
        {
            var posts = forumService.GetPostsByCategoryId(categoryId);

            return View(posts);
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new PostInputModel()
            {
                Categories = this.categoriesService.GetAll()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatorId = this.User.GetId();

            int postId = forumService.AddPost(
                model.Title, model.Content, model.PostCategoryId, model.CreatorId);

            return RedirectToAction(nameof(ByCategoryId), new { id = postId });
        }
    }
}
