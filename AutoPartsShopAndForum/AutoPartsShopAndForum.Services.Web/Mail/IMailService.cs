namespace AutoPartsShopAndForum.Services.Web.Mail
{
    using System.Collections.Generic;
    using AutoPartsShopAndForum.Services.Data.Mail;

    public interface IMailService
    {
        ICollection<SellerModel> GetAvailableSellers();
    }
}
