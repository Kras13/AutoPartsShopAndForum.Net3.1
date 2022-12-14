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

        public SubCategoryModel[] GetSubcategories(int? categoryId = null)
        {
            var result = this.dbContext.Subcategories
                .AsQueryable();

            if (categoryId.HasValue)
            {
                result = result
                    .Where(c => c.CategoryId == categoryId);
            }

            return result
                .Select(c => new SubCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArray();
        }
    }
}
