namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext context;

        public CategoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<PostCategoryModel> GetAll()
        {
            return this.context.PostCategories
                .Select(pc => new PostCategoryModel()
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
