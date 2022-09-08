namespace AutoPartsShopAndForum.Services.Data.Product
{
    public class ProductInputModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int SubcategoryId { get; set; }

        public string CreatorId { get; set; }
    }
}
