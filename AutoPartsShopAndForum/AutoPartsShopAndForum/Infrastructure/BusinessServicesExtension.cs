namespace AutoPartsShopAndForum.Infrastructure
{
    using AutoPartsShopAndForum.Services.Web.Category;
    using AutoPartsShopAndForum.Services.Web.Forum;
    using AutoPartsShopAndForum.Services.Web.Mail;
    using AutoPartsShopAndForum.Services.Web.Order;
    using AutoPartsShopAndForum.Services.Web.Product;
    using AutoPartsShopAndForum.Services.Web.Town;
    using AutoPartsShopAndForum.Services.Web.User;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessServicesExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ITownService, TownService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<ICategoriesService, CategoriesService>();

            return services;
        }
    }
}