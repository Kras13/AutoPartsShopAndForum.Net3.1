namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models.View.Query.Products;
    using AutoPartsShopAndForum.Services.Data.Product;
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

        public IActionResult All(ProductQueryViewModel queryModel)
        {
            int? categoryId = null;

            if (queryModel.CategoryId.HasValue)
            {
                categoryId = queryModel.CategoryId.Value;
            }

            var products = productService.GetQueriedProducts(
                queryModel.SearchCriteria, queryModel.CategoryId, queryModel.Sorting);

            var model = new ProductQueryViewModel()
            {
                CategoryId = categoryId,
                Products = products,
                SearchCriteria = String.Empty,
                Sorting = Services.Data.Product.ProductSorting.NoSorting
            };

            return View(model);
        }

        public IActionResult Details(ProductModel model)
        {
            return View(model);
        }
    }
}