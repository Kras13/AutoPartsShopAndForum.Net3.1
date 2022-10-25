namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
    using AutoPartsShopAndForum.Services.Data.Forum;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Create(string title, string content, int postCategoryId, string creatorId)
        {
            var entity = context.Posts.Add(
                new Post()
                {
                    Title = title,
                    Content = content,
                    PostCategoryId = postCategoryId,
                    CraetorId = creatorId,
                    CreatedOn = DateTime.UtcNow
                }).Entity;

            context.SaveChanges();

            return entity.Id;
        }

        public PostModel ById(int postId)
        {
            var post = this.context.Posts
                .Include(c => c.Creator)
                .FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                return null;
            }

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

            return new PostModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = comments,
                CreatedOn = ParsePostCreateDate(post.CreatedOn),
                CreatorUserName = post.Creator.UserName
            };
        }

        public ICollection<PostModel> ByCategoryId(int id)
        {
            var posts = this.context.Posts
                .Include(p => p.Creator)
                .Where(p => p.PostCategoryId == id);

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
                    Comments = comments,
                    CreatedOn = ParsePostCreateDate(post.CreatedOn),
                    CreatorUserName = post.Creator.UserName
                });
            }

            return postsModels;
        }

        private string ParsePostCreateDate(DateTime createdOn)
        {
            string pattern = "MM-dd-yy";

            return createdOn.ToString(pattern);
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
    }
}
