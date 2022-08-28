namespace AutoPartsShopAndForum.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(Constants.User.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(Constants.User.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(Constants.User.EGNMaxLength)]
        public string EGN { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
