using AutoPartsShopAndForum.Data;
using AutoPartsShopAndForum.Data.Models;
using AutoPartsShopAndForum.Services.Data.Product;
using System.Collections.Generic;

namespace AutoPartsShopAndForum.Services.Web.Cart
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext context;

        public CartService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int OrderProducts(
            ICollection<ProductModel> products, string userId, int townId, string street)
        {
            // orders -> productsorders
            int orderId = -1;

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var order = context.Orders.Add(new Order()
                    { });
                }
                finally
                {
                    transaction.Rollback();
                }
            }


        }
    }
}