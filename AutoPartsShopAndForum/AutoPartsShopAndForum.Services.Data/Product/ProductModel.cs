namespace AutoPartsShopAndForum.Services.Data.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int SubcategoryId { get; set; }

        public int CategoryId { get; set; }
    }
}