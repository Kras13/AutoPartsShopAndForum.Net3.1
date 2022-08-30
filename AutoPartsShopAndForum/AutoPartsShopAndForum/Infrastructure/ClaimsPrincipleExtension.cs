namespace AutoPartsShopAndForum.Infrastructure
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using System.Security.Claims;

    public static class ClaimsPrincipleExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(Role.Administrator);
        }

        public static bool IsSeller(this ClaimsPrincipal user)
        {
            return user.IsInRole(Role.Seller);
        }
    }
}
