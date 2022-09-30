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
    using AutoPartsShopAndForum.Models.View.User;

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
        public IActionResult Candidate(UserCandidateInputModel model)
        {
            if (User.IsInRole(Role.Seller) || User.IsInRole(Role.Administrator))
            {
                throw new InvalidOperationException(
                    "Administrators and Sellers can not candidate");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.SeccessfulyCandidate = true;

            return View();
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
