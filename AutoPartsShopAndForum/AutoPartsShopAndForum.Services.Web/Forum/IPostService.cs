namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;

    public interface IPostService
    {
        int Create(string title, string content, int postCategoryId, string creatorId);

        PostModel ById(int id);

        ICollection<PostModel> ByCategoryId(int id);
    }
}
