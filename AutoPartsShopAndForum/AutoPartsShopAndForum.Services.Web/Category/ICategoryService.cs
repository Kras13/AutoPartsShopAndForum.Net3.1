namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Services.Data.Category;
    using AutoPartsShopAndForum.Services.Data.Subcategory;

    public interface ICategoryService
    {
        CategoryModel[] GetCategories();

        SubCategoryModel[] GetSubcategories();
    }
}
