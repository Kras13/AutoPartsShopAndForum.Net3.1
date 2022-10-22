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

        public PostsController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public IActionResult Categories()
        {
            var categories = forumService.GetAllCategories();

            return View(categories);
        }

        public IActionResult ById(int id)
        {
            var posts = forumService.GetPostsByCategoryId(id);
            return View(posts);
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new PostInputModel()
            {
                Categories = this.forumService.GetAllCategories()
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

            return RedirectToAction(nameof(ById), new { id = postId });
        }
    }
}
