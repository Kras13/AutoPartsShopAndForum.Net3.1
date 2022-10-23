namespace AutoPartsShopAndForum.Services.Web.Forum
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        ICollection<PostCategoryModel> GetAll();
    }
}