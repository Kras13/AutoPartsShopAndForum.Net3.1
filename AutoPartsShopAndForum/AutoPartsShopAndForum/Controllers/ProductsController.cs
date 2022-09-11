namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models.View.Query.Products;
    using AutoPartsShopAndForum.Models.View.Query.SubCategory;
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Web.Category;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult All(ProductQueryViewModel queryModel)
        {
            int? categoryId = null;

            if (queryModel.CategoryId.HasValue)
            {
                categoryId = queryModel.CategoryId.Value;
            }

            var subCategories = categoryService
               .GetSubcategories(categoryId)
               .Select(s => new SubcategorySelectModel()
               {
                   Id = s.Id,
                   Name = s.Name,
                   Selected = false
               }).ToList();

            if (queryModel.SubCategories != null)
            {
                subCategories = queryModel.SubCategories.ToList();
            }

            var products = productService.GetQueriedProducts(
                queryModel.SearchCriteria, queryModel.CategoryId, queryModel.Sorting)
                .Where(s => subCategories.Any(c => c.Id == s.SubcategoryId))
                .ToArray();

            var model = new ProductQueryViewModel()
            {
                CategoryId = categoryId,
                Products = products,
                SubCategories = subCategories,
                SearchCriteria = String.Empty,
                Sorting = Services.Data.Product.ProductSorting.NoSorting
            };

            return View(model);
        }

        public IActionResult Details(ProductDetailsModel model)
        {
            string goBackUrl = Request.Headers["Referer"];

            if (!string.IsNullOrEmpty(model.LastUrl.Trim()))
            {
                goBackUrl = model.LastUrl;
            }

            model.LastUrl = goBackUrl;

            return View(model);
        }
    }
}