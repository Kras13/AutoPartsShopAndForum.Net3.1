namespace AutoPartsShopAndForum.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CartController : Controller
    {
        public CartController()
        {

        }

        public IActionResult All()
        {
            string model =
                JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Cart"));

            return View(model);
        }
    }
}
