namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Services.Data.Home;
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public class ProductQueryViewModel
    {
        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}