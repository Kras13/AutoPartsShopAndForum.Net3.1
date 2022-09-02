namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models.View.Query.Products;
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

        public IActionResult AllByCategory(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Products/GetAll invalid categoryId");
            }

            var products = productService.GetProductsByCategoryId(id);

            var model = new ProductQueryViewModel() 
            {
                Category = null,
                Products = products,
                SearchCriteria = String.Empty,
                Sorting = Services.Data.Product.ProductSorting.NoSorting
            };

            return View(model);
        }
    }
}
