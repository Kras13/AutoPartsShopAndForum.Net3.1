namespace AutoPartsShopAndForum.Services.Data.Product.InputModel
{
    using System.ComponentModel.DataAnnotations;
    using AutoPartsShopAndForum.Data.Models.Constants;
    using AutoPartsShopAndForum.Services.Data.Home;

    public class ProductAddInputModel
    {
        [Required]
        [MaxLength(Product.NameMaxLength)]
        [MinLength(Product.NameMinLength, ErrorMessage = "Please enter at least 2 symbols")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(Product.DescriptionMaxLength)]
        [MinLength(Product.DescriptionMinLength, ErrorMessage = "Please enter at least 2 symbols")]
        public string Description { get; set; }

        public CategoryModel[] Categories { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CreatorId { get; set; }
    }
}