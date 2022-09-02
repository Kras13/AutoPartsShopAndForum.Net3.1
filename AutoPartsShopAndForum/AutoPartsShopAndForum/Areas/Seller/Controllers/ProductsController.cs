namespace AutoPartsShopAndForum.Areas.Seller.Controllers
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;
    using AutoPartsShopAndForum.Services.Web.Category;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
                Categories = categoryService.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductAddInputModel model)
        {
            // validate model
            model.CreatorId = this.User.GetId();
            productService.AddProduct(model);

            return Redirect("/Home/Index");
        }
    }
}
