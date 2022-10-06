namespace AutoPartsShopAndForum.Areas.Orders.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Web.Order;
    using Microsoft.AspNetCore.Mvc;

    public class UserOrdersController : Controller
    {
        private readonly IOrderService orderService;

        public UserOrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Test() 
        {
            var userOrders = this.orderService.GetOrderedProducts(this.User.GetId());

            return this.Json(userOrders);
        }
    }
}
