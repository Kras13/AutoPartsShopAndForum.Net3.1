namespace AutoPartsShopAndForum.Models.View.Query.Cart
{
    public class ProductCartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get { return this.Price * Quantity; } }

        public bool Added { get; set; }

        public string LastUrl { get; set; }
    }
}
