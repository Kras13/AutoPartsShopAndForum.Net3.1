namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;

    public interface IForumService
    {
        ICollection<PostCategoryModel> GetAllCategories();

        int AddPost(string title, string content, int postCategoryId, string creatorId);

        PostModel GetPost(int postId);

        void CreateComment(int postId, string userId, string content, int? parentId = null);

        bool IsCommentInPost(int commentId, int postId);
    }
}
