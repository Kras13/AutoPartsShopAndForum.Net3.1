namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Models.View.Query.Cart;
    using AutoPartsShopAndForum.Models.View.Query.Products;
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

        public void ChangeProduct(int id, int quantity)
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            var selectedModel = cartCollection.FirstOrDefault(m => m.Id == id);

            selectedModel.Quantity = quantity;

            HttpContext.Session.SetObject("Cart", cartCollection);
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
                cartCollection.Add(model);
            }

            model.Added = true;
            HttpContext.Session.SetObject("Cart", cartCollection);

            var productDetailsRedirectModel = new ProductDetailsModel()
            {
                Id = model.Id,
                AddedToCart = model.Added,
                Name = model.Name
            };

            return RedirectToAction("Details", "Products", new { area = "", productDetailsRedirectModel });
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