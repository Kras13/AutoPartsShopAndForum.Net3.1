using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPartsShopAndForum.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.ProductOrders = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Creator))]
        [Required]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<OrderProduct> ProductOrders { get; set; }
    }
}
