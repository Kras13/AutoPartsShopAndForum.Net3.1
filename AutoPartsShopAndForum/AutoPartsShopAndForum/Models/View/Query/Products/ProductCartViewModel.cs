namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Data.Town;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductCartViewModel
    {
        public ICollection<ProductCartModel> Products { get; set; }

        public string LastUrl { get; set; }

        [Display(Name = "Town")]
        public ICollection<TownModel> Towns { get; set; }

        public int SelectedTownId { get; set; }

        public static bool PropertiesAssigned(ProductCartViewModel model)
        {
            return model != null && model.Products != null && model.Towns != null;
        }
    }
}