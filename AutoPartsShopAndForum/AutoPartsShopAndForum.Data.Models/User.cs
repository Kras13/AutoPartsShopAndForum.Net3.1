namespace AutoPartsShopAndForum.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(Constants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(Constants.UserNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(Constants.EGNMaxLength)]
        public string EGN { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }
    }
}
