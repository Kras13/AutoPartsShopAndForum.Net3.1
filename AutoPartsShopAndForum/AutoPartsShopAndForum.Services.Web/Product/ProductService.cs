namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddProduct(ProductInputModel product)
        {
            var entity = context.Products.Add(
                 new AutoPartsShopAndForum.Data.Models.Product()
                 {
                     Name = product.Name,
                     Price = product.Price,
                     Description = product.Description,
                     ImageUrl = product.ImageUrl,
                     SubcategoryId = product.SubcategoryId,
                     CreatorId = product.CreatorId
                 });

            context.SaveChanges();

            return entity.Entity.Id;
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public ProductModel GetProduct(int id)
        {
            var model = this.context.Products
                .FirstOrDefault(p => p.Id == id);
            return new ProductModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                SubcategoryId = model.SubcategoryId,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
        }

        public ICollection<ProductModel> GetQueriedProducts(
            string searchCriteria,
            ProductSorting Sorting,
            int? categoryId)
        {
            var entities = context.Products
                    .Include(e => e.Subcategory)
                    .ThenInclude(e => e.Category)
                    .AsQueryable();

            if (categoryId.HasValue)
            {
                entities = entities
                    .Where(e => e.Subcategory.CategoryId == categoryId);
            }

            return entities
                .Select(e => new ProductModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    SubcategoryId = e.SubcategoryId,
                    CategoryId = e.Subcategory.CategoryId
                }).ToArray();
        }
    }
}