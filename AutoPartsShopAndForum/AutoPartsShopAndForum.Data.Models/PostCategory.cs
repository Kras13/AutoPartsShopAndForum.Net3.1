namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;

    public class PostCategory
    {
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
