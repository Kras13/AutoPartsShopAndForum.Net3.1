namespace AutoPartsShopAndForum.Services.Data.Product.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class ProductAddInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
}
