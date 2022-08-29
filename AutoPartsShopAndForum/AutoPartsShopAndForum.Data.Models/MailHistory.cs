namespace AutoPartsShopAndForum.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MailHistory
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }

        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        [MaxLength(Constants.MailHistory.ThemeMaxLength)]
        public string Theme { get; set; }

        public string Content { get; set; }
    }
}
