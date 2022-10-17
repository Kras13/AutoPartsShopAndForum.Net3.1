namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;

    public interface IForumService
    {
        ICollection<ForumCategoryModel> GetAllCategories();
    }
}
