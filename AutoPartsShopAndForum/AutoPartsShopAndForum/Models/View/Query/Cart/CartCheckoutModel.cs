using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShopAndForum.Models.View.Query.Cart
{
    public class CartCheckoutModel
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string MobileNumber { get; set; }

        public bool SuccessfullyCreatedOrder { get; set; }

        public ICollection<ProductCartModel> Products { get; set; }
    }
}
