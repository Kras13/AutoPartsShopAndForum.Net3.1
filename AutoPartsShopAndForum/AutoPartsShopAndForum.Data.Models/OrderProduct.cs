namespace AutoPartsShopAndForum.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct
    {
        [ForeignKey(nameof(Order))]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal SinglePrice { get; set; }
    }
}
