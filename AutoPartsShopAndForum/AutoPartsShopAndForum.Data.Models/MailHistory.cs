namespace AutoPartsShopAndForum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MailHistory
    {
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        [MaxLength(Constants.MailHistory.ThemeMaxLength)]
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SentOn { get; set; }
    }
}