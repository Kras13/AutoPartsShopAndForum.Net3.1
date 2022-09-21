namespace AutoPartsShopAndForum.Services.Web.Mail
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.Mail;
    using System.Collections.Generic;
    using System.Linq;

    public class MailService : IMailService
    {
        private readonly ApplicationDbContext context;

        public MailService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<SellerModel> GetAvailableSellers()
        {
            var roles = context.Roles.
               Where(r => r.Name == "Administrator" || r.Name == "Seller")
               .AsQueryable();

            var usersInRole = context.UserRoles
                .Where(ur => roles.Any(r => r.Id == ur.RoleId));

            var users = context.Users
                .Where(u => usersInRole.Any(ur => ur.UserId == u.Id));

            return users
                .Select(u => new SellerModel()
                {
                    Id = u.Id,
                    Name = u.FirstName + u.LastName
                }).ToArray();
        }
    }
}