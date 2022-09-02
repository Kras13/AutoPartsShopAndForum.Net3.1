namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Home;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CategoryModel[] GetCategories()
        {
            return this.dbContext.Categories
                .Select(
                c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl
                }).ToArray();
        }
    }
}
