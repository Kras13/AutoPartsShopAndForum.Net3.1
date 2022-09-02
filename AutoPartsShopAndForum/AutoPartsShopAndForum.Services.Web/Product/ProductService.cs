namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddProduct(ProductAddInputModel product)
        {
            var entity = context.Products.Add(
                 new AutoPartsShopAndForum.Data.Models.Product()
                 {
                     Name = product.Name,
                     Price = product.Price,
                     Description = product.Description,
                     ImageUrl = product.ImageUrl,
                     CategoryId = product.SelectedCategoryId,
                     CreatorId = product.CreatorId
                 });


            context.SaveChanges();

            return entity.Entity.Id;
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ProductModel> GetProductsByCategoryId(int id)
        {
            return context.Products
                .Where(p => p.CategoryId == id)
                .Select(
                e => new ProductModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Desctiption = e.Description,
                    ImageUrl = e.ImageUrl,
                    CategoryId = e.CategoryId
                }).ToArray();
        }
    }
}
