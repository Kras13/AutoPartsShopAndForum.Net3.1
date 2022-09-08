namespace AutoPartsShopAndForum.Services.Data.Category
{
    using AutoPartsShopAndForum.Services.Data.Subcategory;

    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public SubCategoryModel[] SubCategories { get; set; }
    }
}
