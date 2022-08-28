namespace AutoPartsShopAndForum.Data.Models
{
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

        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(OrderDetail))]
        [Required]
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
