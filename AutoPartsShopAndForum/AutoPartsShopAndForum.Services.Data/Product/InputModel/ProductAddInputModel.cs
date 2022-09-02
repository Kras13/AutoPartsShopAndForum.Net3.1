namespace AutoPartsShopAndForum.Services.Data.Product.InputModel
{
    using System.ComponentModel.DataAnnotations;
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Services.Data.Home;

    public class ProductAddInputModel
    {
        [Required]
        [MaxLength(Product.NameMaxLength)]
        [MinLength(Product.NameMinLength, ErrorMessage = "Please enter at least 2 symbols" )]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(Product.DescriptionMaxLength)]
        [MinLength(Product.DescriptionMinLength, ErrorMessage = "Please enter at least 2 symbols")]
        public string Description { get; set; }

        [Required]
        public CategoryModel[] Categories { get; set; }

        public int SelectedCategoryId { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
}