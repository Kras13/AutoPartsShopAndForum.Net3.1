namespace AutoPartsShopAndForum.Services.Web.Forum
{
    public interface ICommentService
    {
        int Create(int postId, string userId, string content, int? parentId = null);

        bool IsCommentInPost(int commentId, int postId);
    }
}
