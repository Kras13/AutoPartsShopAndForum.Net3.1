namespace AutoPartsShopAndForum.Areas.Orders.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Web.Order;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UserOrdersController : OrdersBaseController
    {
        private readonly IOrderService orderService;

        public UserOrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult List()
        {
            var userOrders = this.orderService.GetOrderedProducts(this.User.GetId());

            return View(userOrders);
        }

        //[Authorize]
        //public IActionResult Details(int orderId)
        //{
        //    var userOrders = this.orderService.GetOrderedProducts(this.User.GetId());

        //    //return View(userOrders);

        //    return this.Json(userOrders);
        //}
    }
}
