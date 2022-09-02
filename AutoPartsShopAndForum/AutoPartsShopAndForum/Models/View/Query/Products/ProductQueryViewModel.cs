namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Services.Data.Product.ViewModel;
    using System.Collections.Generic;

    public class ProductQueryViewModel
    {
        public string SearchCriteria { get; set; }

        public ProductSorting Sorting { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}