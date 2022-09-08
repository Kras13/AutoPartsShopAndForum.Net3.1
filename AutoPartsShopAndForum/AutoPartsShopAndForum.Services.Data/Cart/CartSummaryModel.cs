namespace AutoPartsShopAndForum.Services.Data.Cart
{
    using System.Collections.Generic;

    public class CartSummaryModel
    {
        public ICollection<ProductCartModel> Products { get; set; }

        public decimal Total { get; set; }
    }
}