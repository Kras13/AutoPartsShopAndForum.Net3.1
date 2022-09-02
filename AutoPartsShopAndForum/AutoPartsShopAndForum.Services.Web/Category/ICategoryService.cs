namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Services.Data.Home.ViewModel;

    public interface ICategoryService
    {
        CategoryViewModel[] GetCategories();
    }
}
