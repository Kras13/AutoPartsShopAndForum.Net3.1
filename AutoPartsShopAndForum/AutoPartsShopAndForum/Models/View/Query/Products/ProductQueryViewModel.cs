namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Models.View.Query.SubCategory;
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public class ProductQueryViewModel
    {
        public ProductQueryViewModel()
        {
            Sorting = ProductSorting.NoSorting;
        }

        public ICollection<ProductModel> Products { get; set; }

        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public int? CategoryId { get; set; }

        public List<SubcategorySelectModel> SubCategories { get; set; }
    }
}