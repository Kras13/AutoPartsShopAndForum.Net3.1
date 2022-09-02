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

        public IActionResult AllByCategory(ProductQueryViewModel queryModel)
        {
            int categoryId = queryModel.CategoryId == null ? -1 : queryModel.CategoryId.Value;

            if (categoryId < 0)
            {
                throw new ArgumentException("Products/GetAll invalid categoryId");
            }

            var products = productService.GetQueriedProducts(
                queryModel.SearchCriteria, queryModel.CategoryId.Value, queryModel.Sorting);

            var model = new ProductQueryViewModel() 
            {
                CategoryId = categoryId,
                Products = products,
                SearchCriteria = String.Empty,
                Sorting = Services.Data.Product.ProductSorting.NoSorting
            };

            return View(model);
        }
    }
}
