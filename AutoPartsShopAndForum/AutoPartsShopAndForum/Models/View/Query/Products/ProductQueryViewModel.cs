namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Models.View.Query.SubCategory;
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

        public List<SubcategorySelectModel> SubCategories { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}