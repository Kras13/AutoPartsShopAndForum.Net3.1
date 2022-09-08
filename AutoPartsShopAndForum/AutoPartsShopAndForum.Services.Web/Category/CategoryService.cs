namespace AutoPartsShopAndForum.Services.Web.Category
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Category;
    using AutoPartsShopAndForum.Services.Data.Subcategory;
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

        public SubCategoryModel[] GetSubcategories()
        {
            return this.dbContext.Subcategories
                .Select(s => new SubCategoryModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToArray();
        }
    }
}
