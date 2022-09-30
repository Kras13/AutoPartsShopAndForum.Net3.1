namespace AutoPartsShopAndForum.Services.Web.User
{
    using AutoPartsShopAndForum.Services.Data.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        ICollection<PendingUserModel> GetPendingUsers();

        void Candidate(string userId, string motivation);
    }
}
