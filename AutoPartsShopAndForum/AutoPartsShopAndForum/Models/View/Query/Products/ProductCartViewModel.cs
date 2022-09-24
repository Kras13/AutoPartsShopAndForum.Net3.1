namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Services.Data.Product;

    public class ProductCartViewModel : ProductCartModel
    {
        public bool Added { get; set; }

        public string LastUrl { get; set; }
    }
}