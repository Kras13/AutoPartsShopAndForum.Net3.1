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

        [Required]
        [MaxLength(Constants.Category.MaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
