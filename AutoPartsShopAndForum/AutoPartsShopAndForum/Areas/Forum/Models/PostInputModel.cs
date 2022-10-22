namespace AutoPartsShopAndForum.Areas.Forum.Models
{
    using AutoPartsShopAndForum.Services.Data.Forum;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        

        [Required]
        public int PostCategoryId { get; set; }

        public string CreatorId { get; set; }

        public ICollection<PostCategoryModel> Categories { get; set; }
    }
}
