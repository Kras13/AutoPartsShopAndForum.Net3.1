namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;
    using System.Linq;

    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext context;

        public ForumService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<ForumCategoryModel> GetAllCategories()
        {
            return this.context.PostCategories
                .Select(pc => new ForumCategoryModel()
                {
                    Id = pc.Id,
                    Description = pc.Description,
                    ImageUrl = pc.ImageUrl,
                    Name = pc.Name,
                    PostsCount = pc.Posts.Count()
                }).ToArray();
        }
    }
}
