namespace AutoPartsShopAndForum.Models.View.Query.Cart
{
    using System.Collections.Generic;

    public class CartViewModel
    {
        public decimal Total { get; set; }

        public ICollection<ProductCartModel> Products { get; set; }
    }
}