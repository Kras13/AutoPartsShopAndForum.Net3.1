using AutoPartsShopAndForum.Services.Data.Mail;
using System.Collections.Generic;

namespace AutoPartsShopAndForum.Services.Web.Mail
{

    public interface IЕMailService
    {
        int SendEmail(
            string from, string to, string subject, string body);

        ICollection<MailModel> UserEmails(string userId);

        MailModel MailInfoById(string userId, string emailId);
    }
}
