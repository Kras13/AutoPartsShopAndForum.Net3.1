namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models.View.Query.Products;
    using AutoPartsShopAndForum.Models.View.Query.SubCategory;
    using AutoPartsShopAndForum.Services.Web.Category;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
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

            var subCategories = new List<SubcategorySelectModel>();

            if (queryModel.SubCategories != null)
            {
                subCategories = queryModel.SubCategories.ToList();
            }
            else
            {
                subCategories = categoryService
                    .GetSubcategories(categoryId)
                    .Select(s => new SubcategorySelectModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Selected = false
                    }).ToList();
            }

            var selectedSubCategories = new List<int>();

            foreach (var subCat in subCategories)
            {
                if (subCat.Selected)
                {
                    selectedSubCategories.Add(subCat.Id);
                }
            }

            var products = productService.GetQueriedProducts(
                queryModel.CurrentPage,
                queryModel.ProductsPerPage,
                queryModel.SearchCriteria,
                queryModel.Sorting,
                queryModel.CategoryId,
                selectedSubCategories);

            var model = new ProductQueryViewModel()
            {
                CategoryId = categoryId,
                Products = products.Products,
                CurrentPage = queryModel.CurrentPage,
                ProductsPerPage = queryModel.ProductsPerPage,
                TotalProducts = products.TotalProducts,
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