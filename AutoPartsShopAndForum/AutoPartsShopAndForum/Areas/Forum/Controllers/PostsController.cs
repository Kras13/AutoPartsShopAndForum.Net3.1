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

        public IActionResult ById(int id)
        {
            var post = forumService.GetPost(id);
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int postId = forumService.AddPost(
                model.Title, model.Content, model.PostCategoryId, this.User.GetId());

            return RedirectToAction(nameof(ById), new { id = postId });
        }
    }
}
