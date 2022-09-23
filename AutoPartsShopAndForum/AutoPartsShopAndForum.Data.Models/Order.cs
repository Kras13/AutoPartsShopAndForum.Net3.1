namespace AutoPartsShopAndForum.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public decimal OverallSum { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateDelivered { get; set; }

        public string Street { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}