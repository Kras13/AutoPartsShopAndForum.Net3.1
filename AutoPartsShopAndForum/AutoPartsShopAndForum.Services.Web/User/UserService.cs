namespace AutoPartsShopAndForum.Services.Web.User
{
    using AutoPartsShopAndForum.Data;
    using System;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Candidate(string userId, string motivation)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.PendingSellers.Add(new AutoPartsShopAndForum.Data.Models.PendingSeller()
                    {
                        UserId = userId,
                        SelfDescription = motivation,
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
    }
}
