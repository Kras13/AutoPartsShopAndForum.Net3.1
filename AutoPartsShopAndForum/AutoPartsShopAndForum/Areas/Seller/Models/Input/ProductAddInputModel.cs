namespace AutoPartsShopAndForum.Areas.Seller.Models.Input
{
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Services.Data.Subcategory;
    using System.ComponentModel.DataAnnotations;

    public class ProductAddInputModel
    {
        [Required]
        [MaxLength(Product.NameMaxLength)]
        [MinLength(Product.NameMinLength, ErrorMessage = "Please enter at least 2 symbols")]
        public string Name { get; set; }

        [Required]
        [MinLength(Product.ImageUrlMinLength)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(Product.DescriptionMaxLength)]
        [MinLength(Product.DescriptionMinLength, ErrorMessage = "Please enter at least 2 symbols")]
        public string Description { get; set; }

        public SubCategoryModel[] SubCategories { get; set; }

        [Required]
        [Display(Name = "Subcategory")]
        public int SelectedSubcategoryId { get; set; }

        public string CreatorId { get; set; }
    }
}