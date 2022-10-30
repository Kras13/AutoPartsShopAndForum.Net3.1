namespace AutoPartsShopAndForum.Services.Web.Mail
{
    using AutoPartsShopAndForum.Data;
    using System.Linq;
    using System;
    using AutoPartsShopAndForum.Data.Models;
    using AutoPartsShopAndForum.Services.Data.Mail;
    using System.Collections.Generic;

    public class MailService : IЕMailService
    {
        private readonly ApplicationDbContext context;

        public MailService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MailModel MailInfoById(string userId, string emailId)
        {
            throw new NotImplementedException();
        }

        public int SendEmail(
           string from, string to, string subject, string body)
        {
            var selectedUsers = this.context.Users
                .Where(u => u.Id == from || u.Id == to)
                .ToArray();

            if (selectedUsers.Length <= 1)
            {
                throw new ArgumentException("MailService.SendEmail -> Sender or/and reciever can not be found");
            }

            if (selectedUsers.Length > 2)
            {
                throw new Exception("MailService.SendEmail -> Duplicate users...");
            }

            MailHistory mail = new MailHistory()
            {
                SenderId = from,
                ReceiverId = to,
                Subject = subject,
                Body = body
            };

            this.context.MailsHistories.Add(mail);

            return mail.Id;
        }

        public ICollection<MailModel> UserEmails(string userId)
        {
            throw new NotImplementedException();
        }
    }
}