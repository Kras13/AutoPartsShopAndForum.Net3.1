namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Services.Data.Home;

    public interface ICategoryService
    {
        CategoryModel[] GetCategories();
    }
}
