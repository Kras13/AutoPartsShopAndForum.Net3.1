namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Models.View.Input.Cart;
    using AutoPartsShopAndForum.Models.View.Query.Cart;
    using AutoPartsShopAndForum.Services.Web.Town;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CartController : Controller
    {
        private readonly ITownService townService;

        public CartController(ITownService townService)
        {
            this.townService = townService;
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

        public void RemoveProduct(int id)
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            var selectedModel = cartCollection.FirstOrDefault(m => m.Id == id);

            cartCollection.Remove(selectedModel);

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

            return RedirectToAction("Details", "Products",
                new
                {
                    Id = model.Id,
                    AddedToCart = model.Added,
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    LastUrl = model.LastUrl
                });
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

        [Authorize]
        public IActionResult Checkout()
        {
            var products = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            if (products == null || products.Count == 0)
            {
                throw new InvalidOperationException("Can not call Checkout on empty products collection!");
            }

            decimal sum = products.Sum(p => p.Total);

            var model = new CartCheckoutModel()
            {
                Towns = townService.GetAllTowns(),
                TotalAmount = sum

            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(CartCheckoutModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // order products
            // clear the cart

            ViewBag.OrderSuccessful = true;
            return Redirect("Home/Index");
        }
    }
}