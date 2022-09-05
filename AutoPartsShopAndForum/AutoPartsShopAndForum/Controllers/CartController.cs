namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Data.Cart;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    public class CartController : Controller
    {
        public CartController()
        {

        }

        public IActionResult All()
        {
            var model = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            return View(model);
        }

        public IActionResult Add(ProductCartModel model)
        {
            // add the product in the session

            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            if (cartCollection == null)
            {
                cartCollection = new List<ProductCartModel>(); 
            }

            if (!cartCollection.Any(p => p.Name == model.Name))
            {
                cartCollection.Add(model);
            }
            
            model.Added = true;
            model.Quantity++;

            HttpContext.Session.SetObject("Cart", cartCollection);

            return View(model);
        }
    }
}