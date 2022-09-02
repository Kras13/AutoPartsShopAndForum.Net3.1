namespace AutoPartsShopAndForum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PendingSeller
    {
        public PendingSeller()
        {
            Approoved = false;
            DateCandidate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime DateCandidate { get; set; }
        
        [Required]
        [MaxLength(Constants.PendingSeller.SelfDescriptionMaxLength)]
        public string SelfDescription { get; set; }

        public bool Approoved { get; set; }
    }
}
