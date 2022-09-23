namespace AutoPartsShopAndForum.Models.View.Input.Cart
{
    using AutoPartsShopAndForum.Services.Data.Town;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CartCheckoutModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Town")]
        public ICollection<TownModel> Towns { get; set; }

        public int SelectedTownId { get; set; }
    }
}