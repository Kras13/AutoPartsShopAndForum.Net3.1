namespace AutoPartsShopAndForum.Services.Data.Product
{
    using System.Collections.Generic;

    public class ProductQueryModel
    {
        public int TotalProducts { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}