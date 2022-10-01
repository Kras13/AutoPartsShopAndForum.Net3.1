namespace AutoPartsShopAndForum.Services.Web.User
{
    using AutoPartsShopAndForum.Services.Data.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        ICollection<PendingUserModel> GetPendingUsers();

        void ApproveSeller(string adminId, string userId);
    }
}
