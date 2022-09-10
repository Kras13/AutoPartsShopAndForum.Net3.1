namespace AutoPartsShopAndForum.Models.View.Query.Cart
{
    public class ProductCartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public bool Added { get; set; }
    }
}
