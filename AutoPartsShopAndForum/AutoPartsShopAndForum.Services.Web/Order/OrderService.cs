namespace AutoPartsShopAndForum.Services.Web.Order
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
    using AutoPartsShopAndForum.Services.Data.Order;
    using AutoPartsShopAndForum.Services.Data.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<OrderModel> GetOrderedProducts(string userId)
        {
            var result = new List<OrderModel>();

            var userOrders = this.context.Orders
                .Include(u => u.User)
                .Include(t => t.Town)
                .Where(o => o.UserId == userId)
                .ToArray();

            foreach (var order in userOrders)
            {
                var currentOrder = new OrderModel()
                {
                    Id = order.Id,
                    Street = order.Street,
                    Town = order.Town.Name,
                    Products = order.OrderProducts.Select(p => new ProductCartModel()
                    {
                        Id = p.ProductId,
                        Description = p.Product.Description,
                        ImageUrl = p.Product.ImageUrl,
                        Name = p.Product.Name,
                        Price = p.SinglePrice,
                        Quantity = p.Quantity
                    }).ToArray()
                };

                result.Add(currentOrder);
            }

            return result;
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
                        DateCreated = System.DateTime.Now,
                        OverallSum = products.Sum(p => p.Price * p.Quantity),
                        TownId = townId,
                        UserId = userId
                    });

                    orderId = order.Entity.Id;

                    foreach (var product in products)
                    {
                        order.Entity.OrderProducts.Add(new OrderProduct()
                        {
                            OrderId = orderId,
                            ProductId = product.Id,
                            SinglePrice = product.Price,
                            Quantity = product.Quantity
                        });
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch(System.Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }

            return orderId;
        }
    }
}
