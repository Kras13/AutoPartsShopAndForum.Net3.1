namespace AutoPartsShopAndForum.Areas.Seller.Controllers
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;
    using AutoPartsShopAndForum.Services.Web.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(Role.Seller)]
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

        //[Authorize(Roles = Role.Seller)]
        [HttpPost]
        public IActionResult Add(ProductAddInputModel model)
        {
            // validate model


            return Redirect("/Home/Index");
        }
    }
}
