namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models;
    using AutoPartsShopAndForum.Services.Web.Category;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = categoryService.GetCategories();

            return View(categories);
        }

        public IActionResult Privacy()
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject("Krasi"));

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
