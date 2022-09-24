namespace AutoPartsShopAndForum.Services.Data.Order
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public class OrderModel
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public ICollection<ProductCartModel> Products { get; set; }
    }
}
