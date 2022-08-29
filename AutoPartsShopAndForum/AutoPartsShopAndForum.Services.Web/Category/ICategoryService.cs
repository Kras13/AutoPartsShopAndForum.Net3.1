namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Services.Data.Home;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        SummaryCategoriesModel[] GetCategories();
    }
}
