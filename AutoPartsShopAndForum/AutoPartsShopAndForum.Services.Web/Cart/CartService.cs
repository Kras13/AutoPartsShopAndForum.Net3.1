using AutoPartsShopAndForum.Data;
using AutoPartsShopAndForum.Data.Models;
using AutoPartsShopAndForum.Services.Data.Product;
using System.Collections.Generic;
using System.Linq;

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
            ICollection<ProductCartModel> products, string userId, int townId, string street)
        {
            int orderId = -1;

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var order = context.Orders.Add(new Order()
                    {
                        Street = street,
                    });

                    orderId = order.Entity.Id;
                }
                finally
                {
                    transaction.Rollback();
                }
            }

            return orderId;
        }
    }
}