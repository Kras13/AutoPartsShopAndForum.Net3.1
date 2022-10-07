namespace AutoPartsShopAndForum.Services.Web.Order
{
    using AutoPartsShopAndForum.Services.Data.Order;
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public interface IOrderService
    {
        int OrderProducts(ICollection<ProductCartModel> products, string userId, int townId, string street);

        ICollection<OrderModel> GetOrderedProducts(string userId);

        OrderModel GetOrderDetails(int orderId);
    }
}
