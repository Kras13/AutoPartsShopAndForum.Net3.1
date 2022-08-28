namespace AutoPartsShopAndForum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetail
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public decimal OverallSum { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateDelivered { get; set; }
    }
}
