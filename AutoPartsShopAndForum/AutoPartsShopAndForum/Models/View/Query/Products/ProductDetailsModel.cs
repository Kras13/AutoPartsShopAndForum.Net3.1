namespace AutoPartsShopAndForum.Models.View.Query.Products
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; } = 1;

        public bool AddedToCart { get; set; }
    }
}
