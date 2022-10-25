namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
    using System.Linq;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                UserId = userId,
                PostId = postId
            };

            var addedEntity = this.context.Comments.Add(comment);
            this.context.SaveChanges();

            return addedEntity.Entity.Id;
        }

        public bool IsCommentInPost(int commentId, int postId)
        {
            var post = this.context.Posts.FirstOrDefault(p => p.Id == postId);

            bool result = false;

            if (post != null)
            {
                result = post.Comments.Any(c => c.Id == commentId);
            }

            return result;
        }
    }
}
