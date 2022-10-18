namespace AutoPartsShopAndForum.Services.Data.Forum
{
    using System.Collections.Generic;

    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
