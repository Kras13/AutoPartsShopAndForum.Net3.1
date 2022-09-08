namespace AutoPartsShopAndForum.Areas.Seller.Controllers
{
    using AutoPartsShopAndForum.Areas.Seller.Models.Input;
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Web.Category;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Area(Role.Seller)]
    [Authorize(Roles = Role.Seller + "," + Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Add()
        {
            var model = new ProductAddInputModel()
            {
                SubCategories = categoryService.GetSubcategories()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductAddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!this.User.IsAdmin() && !this.User.IsSeller())
            {
                throw new InvalidOperationException("Products/Add -> Only Sellers and Admins can add products");
            }

            productService.AddProduct(new ProductInputModel()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                SubcategoryId = model.SelectedSubcategoryId,
                CreatorId = this.User.GetId()
            });

            return RedirectToAction("All", "Products", new { area = "" });
        }
    }
}