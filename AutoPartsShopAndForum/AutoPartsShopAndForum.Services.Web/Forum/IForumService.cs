namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;

    public interface IForumService
    {
        ICollection<PostCategoryModel> GetAllCategories();

        int AddPost(string title, string content, int postCategoryId, string creatorId);

        ICollection<PostModel> GetPostsByCategoryId(int postCategoryId);

        void CreateComment(int postId, string userId, string content, int? parentId = null);

        bool IsCommentInPost(int commentId, int postId);
    }
}
