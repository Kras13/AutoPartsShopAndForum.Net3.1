namespace AutoPartsShopAndForum.Services.Web.User
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Services.Data.User;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void ApproveSeller(string adminId, string userId)
        {
            var user = context.PendingSellers
                        .FirstOrDefault(p => p.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException("User with the selected id does not exist");
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    user.Approoved = true;
                    user.ApprovedById = adminId;

                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }
        }

        public ICollection<PendingUserModel> GetPendingUsers()
        {
            var pendingUsers = this.context.PendingSellers
                .Where(ps => ps.Approoved == false)
                .Include(p => p.User)
                .Select(pu => new PendingUserModel
                {
                    Id = pu.UserId,
                    FullName = pu.User.FirstName + pu.User.LastName,
                    SelfDescription = pu.SelfDescription
                }).ToArray();

            return pendingUsers;
        }
    }
}
