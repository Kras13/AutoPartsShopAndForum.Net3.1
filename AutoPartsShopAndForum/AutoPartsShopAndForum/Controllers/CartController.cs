namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Data.Cart;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            if (cartCollection == null)
            {
                cartCollection = new List<ProductCartModel>();
            }

            var currentProduct = cartCollection.FirstOrDefault(p => p.Id == model.Id);

            if (currentProduct != null)
            {
                currentProduct.Quantity += model.Quantity;
            }
            else
            {
                model.Added = true;
                cartCollection.Add(model);
            }

            HttpContext.Session.SetObject("Cart", cartCollection);

            return View(model);
        }

        public IActionResult Buy()
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            if (cartCollection != null)
            {
                if (cartCollection.Count > 0)
                {
                    return View();
                }
            }

            return Redirect("Products/All");
        }

        [HttpPost]
        public IActionResult Buy(CartCheckoutModel model)
        {
            return View(model);
        }
    }
}