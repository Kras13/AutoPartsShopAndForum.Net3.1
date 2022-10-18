namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CraetorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey(nameof(PostCategory))]
        public int PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
