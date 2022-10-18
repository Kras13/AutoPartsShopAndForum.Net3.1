namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
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

        public int AddPost(string title, string content, int postCategoryId, string creatorId)
        {
            //todo -> validate the arguments

            int entityId = context.Posts.Add(
                new Post()
                {
                    Title = title,
                    Content = content,
                    PostCategoryId = postCategoryId,
                    CraetorId = creatorId
                }).Entity.Id;

            context.SaveChanges();

            return entityId;
        }

        public ICollection<PostCategoryModel> GetAllCategories()
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
