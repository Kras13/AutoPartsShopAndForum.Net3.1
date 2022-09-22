namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.Users = new HashSet<User>();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.Town.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
