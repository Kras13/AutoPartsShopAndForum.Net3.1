namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.ProductOrders = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }

        [MaxLength(Constants.Product.NameMaxLength)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(Constants.Product.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<OrderProduct> ProductOrders { get; set; }
    }
}
