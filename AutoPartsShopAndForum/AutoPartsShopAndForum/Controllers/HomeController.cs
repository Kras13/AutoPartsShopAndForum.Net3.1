namespace AutoPartsShopAndForum.Controllers
{
    using AutoPartsShopAndForum.Models;
    using AutoPartsShopAndForum.Services.Web.Category;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Diagnostics;
    using AutoPartsShopAndForum.Data.Models.Constants;
    using System;
    using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public IActionResult Candidate()
        {
            if (User.IsInRole(Role.Seller) || User.IsInRole(Role.Administrator))
            {
                throw new InvalidOperationException(
                    "Administrators and Sellers can not candidate");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Candidate(string motivation)
        {
            if (User.IsInRole(Role.Seller) || User.IsInRole(Role.Administrator))
            {
                throw new InvalidOperationException(
                    "Administrators and Sellers can not candidate");
            }

            ViewBag.SeccessfulyCandidate = true;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Test(int orderId)
        {
            return this.Content(orderId.ToString());
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
