namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [MaxLength(Constants.Category.MaxLength)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
