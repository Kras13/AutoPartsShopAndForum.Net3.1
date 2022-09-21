﻿namespace AutoPartsShopAndForum.Services.Web.Product
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
            //TODO: argument validation

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

        public ProductQueryModel GetQueriedProducts(
            int currentPageIndex,
            int productsPerPage,
            string searchCriteria,
            ProductSorting sorting,
            int? categoryId,
            IEnumerable<int> selectedSubcategories = null)
        {
            var entities = context.Products
                    .Include(e => e.Subcategory)
                    .ThenInclude(e => e.Category)
                    .AsQueryable();

            if (selectedSubcategories != null && selectedSubcategories.Count() > 0)
            {
                entities = entities
                    .Where(e => selectedSubcategories.Any(s => s == e.SubcategoryId));
            }

            switch (sorting)
            {
                case ProductSorting.PriceAscending:
                    entities = entities
                        .OrderBy(p => p.Price);
                    break;
                case ProductSorting.PriceDescending:
                    entities = entities
                        .OrderByDescending(p => p.Price);
                    break;
                case ProductSorting.DateAscenging:
                    entities = entities
                        .OrderBy(p => p.Id);
                    break;
                case ProductSorting.DateDescending:
                    entities = entities
                        .OrderByDescending(p => p.Id);
                    break;
                case ProductSorting.NameAscending:
                    entities = entities
                        .OrderBy(p => p.Name);
                    break;
                case ProductSorting.NameDescending:
                    entities = entities
                        .OrderByDescending(p => p.Name);
                    break;
            }

            if (categoryId.HasValue)
            {
                entities = entities
                    .Where(e => e.Subcategory.CategoryId == categoryId);
            }

            int totalQueriedEntities = entities.Count();

            return new ProductQueryModel()
            {
                Products = entities
                    .Skip((currentPageIndex - 1) * productsPerPage)
                    .Take(productsPerPage)
                    .Select(e => new ProductModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        CategoryId = categoryId.HasValue ? categoryId.Value : -1,
                        SubcategoryId = e.SubcategoryId,
                        Description = e.Description,
                        ImageUrl = e.ImageUrl,
                        Price = e.Price
                    }).ToArray(),
                TotalProducts = totalQueriedEntities
            };
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

        public ICollection<ProductModel> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}