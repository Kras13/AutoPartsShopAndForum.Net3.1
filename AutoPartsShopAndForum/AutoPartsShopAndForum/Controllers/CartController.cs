namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Models.View.Input.Cart;
    using AutoPartsShopAndForum.Models.View.Query.Products;
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Web.Order;
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
        private readonly IOrderService orderService;

        public CartController(ITownService townService, IOrderService orderService)
        {
            this.townService = townService;
            this.orderService = orderService;
        }

        public IActionResult All()
        {
            var products = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");
            var model = new ProductCartViewModel()
            {
                Products = products,
                Towns = this.townService.GetAllTowns()
            };

            return View(model);
        }

        [Authorize]
        public void ChangeProduct(int id, int quantity)
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            var selectedModel = cartCollection.FirstOrDefault(m => m.Id == id);

            selectedModel.Quantity = quantity;

            HttpContext.Session.SetObject("Cart", cartCollection);
        }

        [Authorize]
        public void RemoveProduct(int id)
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            var selectedModel = cartCollection.FirstOrDefault(m => m.Id == id);

            cartCollection.Remove(selectedModel);

            HttpContext.Session.SetObject("Cart", cartCollection);
        }

        public IActionResult Add(ProductCartModel model, string lastUrl)
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

            HttpContext.Session.SetObject("Cart", cartCollection);

            return RedirectToAction("Details", "Products",
                new
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    AddedToCart = true,
                    LastUrl = lastUrl
                });
        }

        public IActionResult Buy()
        {
            var cartCollection = HttpContext.Session.GetObject<ICollection<ProductCartViewModel>>("Cart");

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
        public IActionResult Checkout(int townId)
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
        public void Finalise(string street, int townId)
        {
            var products = HttpContext.Session.GetObject<ICollection<ProductCartModel>>("Cart");

            if (products == null || products.Count == 0)
            {
                throw new InvalidOperationException("Can not finalise an empty Cart...");
            }

            orderService.OrderProducts(
                products.ToArray(),
                this.User.GetId(),
                townId,
                street);

            products.Clear();

            HttpContext.Session.SetObject("Cart", products);

            TempData["OrderSuccessful"] = 1;
        }
    }
}