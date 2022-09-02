namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult GetAll(int categoryId)
        {
            if (categoryId < 0)
            {
                throw new ArgumentException("Products/GetAll invalid categoryId");
            }

            var products = productService.GetProductsByCategoryId(categoryId);

            return View(model);
        }
    }
}
