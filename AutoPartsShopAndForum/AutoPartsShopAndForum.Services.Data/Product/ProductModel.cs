namespace AutoPartsShopAndForum.Services.Data.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Desctiption { get; set; }

        public int CategoryId { get; set; }
    }
}

//public ICollection<OrderProduct> ProductOrders { get; set; }