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

        public void Approve(string userId, string selfDescription)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.PendingSellers.Add(new AutoPartsShopAndForum.Data.Models.PendingSeller()
                    {
                        UserId = userId,
                        SelfDescription = selfDescription,
                        DateCandidate = DateTime.Now,
                        Approoved = false
                    });

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
