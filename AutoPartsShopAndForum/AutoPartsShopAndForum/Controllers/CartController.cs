namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models.View.Query.Cart;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class CartController : Controller
    {
        public CartController()
        {

        }

        public IActionResult All()
        {
            var model = new CartViewModel()
            {
                Products = cartService.ExtractProductsFromSession();
            };

            string model1 =
                JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Cart"));

            return View();
        }
    }
}