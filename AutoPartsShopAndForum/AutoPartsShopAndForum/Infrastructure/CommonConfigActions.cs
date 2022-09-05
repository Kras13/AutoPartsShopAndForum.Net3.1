using Microsoft.AspNetCore.Builder;
using System.Globalization;

namespace AutoPartsShopAndForum.Infrastructure
{
    public static class CommonConfigActions
    {
        public static void ConfigureDelimeterCultureInfo(
            this IApplicationBuilder app, string delimeter)
        {
            //var cultureInfo = new CultureInfo("de-DE");
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}