namespace AutoPartsShopAndForum.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MailHistory
    {
        public int Id { get; set; }

        [ForeignKey(nameof(FromId))]
        [Required]
        public int FromId { get; set; }
        public User FromUser { get; set; }

        [ForeignKey(nameof(ToUser))]
        [Required]
        public int ToId { get; set; }
        public User ToUser { get; set; }

        [MaxLength(Constants.MailHistory.ThemeMaxLength)]
        public string Theme { get; set; }

        public string Content { get; set; }
    }
}
