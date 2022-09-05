namespace AutoPartsShopAndForum.Services.Data.Cart
{
    using System.Collections.Generic;

    public class CartCheckoutModel
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string MobileNumber { get; set; }

        public bool SuccessfullyCreatedOrder { get; set; }

        public ICollection<ProductCartModel> Products { get; set; }
    }
}