namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Data.Subcategory;
    using System.Collections.Generic;

    public class ProductQueryViewModel
    {
        public ProductQueryViewModel()
        {
            Sorting = ProductSorting.NoSorting;
        }

        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<SubCategoryModel> SubCategories { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}