namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Subcategory
    {
        public Subcategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}