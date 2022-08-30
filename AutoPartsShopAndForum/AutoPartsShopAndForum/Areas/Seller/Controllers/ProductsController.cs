namespace AutoPartsShopAndForum.Areas.Seller.Controllers
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Infrastructure;
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(Role.Seller)]
    [Authorize(Roles = Role.Seller + "," + Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddInputModel model)
        {
            // validate model

            model.CreatorId = this.User.GetId();

            return Redirect("/Home/Index");
        }
    }
}
