namespace AutoPartsShopAndForum.Areas.Administrator.Controllers
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(Role.Administrator)]
    [Authorize(Roles = Role.Administrator)]
    public class BaseAdminController : Controller
    {
    }
}