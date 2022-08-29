namespace AutoPartsShopAndForum.Services.Web
{
    using AutoPartsShopAndForum.Data;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            this._context = context;
        }


    }
}
