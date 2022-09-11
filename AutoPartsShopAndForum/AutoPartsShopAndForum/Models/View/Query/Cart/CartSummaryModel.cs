namespace AutoPartsShopAndForum.Models.View.Query.Cart
{
    using System.Collections.Generic;

    public class CartSummaryModel
    {
        public ICollection<ProductCartModel> Products { get; set; }

        public decimal Total { get; set; }
    }
}
