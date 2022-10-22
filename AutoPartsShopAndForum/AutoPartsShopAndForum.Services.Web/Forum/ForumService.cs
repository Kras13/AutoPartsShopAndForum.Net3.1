namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System;
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

            var entity = context.Posts.Add(
                new Post()
                {
                    Title = title,
                    Content = content,
                    PostCategoryId = postCategoryId,
                    CraetorId = creatorId
                }).Entity;

            context.SaveChanges();

            return entity.Id;
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

        public PostModel GetPost(int postId)
        {
            var post = this.context.Posts.FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                return null;
            }

            IList<CommentModel> comments = new List<CommentModel>();

            foreach (var comment in post.Comments)
            {
                CommentModel parent = GetCurrentCommentParent(comment, comments);

                comments.Add(new CommentModel() { 
                    Id = comment.Id, Parent = parent,  Content = comment.Content});
            }

            return new PostModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = comments
            };
        }

        public void CreateComment(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                UserId = userId,
                PostId = postId
            };

            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public bool IsCommentInPost(int commentId, int postId)
        {
            var post = this.context.Posts.FirstOrDefault(p => p.Id == postId);

            bool result = false;

            if (post != null)
            {
                result =  post.Comments.Any(c => c.Id == commentId);
            }

            return result;
        }

        private CommentModel GetCurrentCommentParent(Comment comment, IList<CommentModel> comments)
        {
            if (comment.Parent == null)
            {
                return null;
            }

            var parentReference = comments.FirstOrDefault(n => n.Id == comment.Parent.Id);

            return parentReference;
        }

        public ICollection<PostModel> GetPostsByCategoryId(int postCategoryId)
        {
            var posts = this.context.Posts.Where(p => p.PostCategoryId == postCategoryId);

            if (posts.Count() == 0)
            {
                return null;
            }

            IList<PostModel> postsModels = new List<PostModel>();

            foreach (var post in posts)
            {
                IList<CommentModel> comments = new List<CommentModel>();

                foreach (var comment in post.Comments)
                {
                    CommentModel parent = GetCurrentCommentParent(comment, comments);

                    comments.Add(new CommentModel()
                    {
                        Id = comment.Id,
                        Parent = parent,
                        Content = comment.Content
                    });
                }

                postsModels.Add(new PostModel() 
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Comments = comments
                });
            }

            return postsModels;
        }
    }
}
