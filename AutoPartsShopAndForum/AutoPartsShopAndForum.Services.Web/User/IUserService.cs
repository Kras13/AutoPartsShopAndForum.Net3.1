namespace AutoPartsShopAndForum.Services.Web.User
{
    using AutoPartsShopAndForum.Services.Data.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        ICollection<PendingUserModel> GetPendingUsers();

        void Approve(string userId, string selfDescription);
    }
}
