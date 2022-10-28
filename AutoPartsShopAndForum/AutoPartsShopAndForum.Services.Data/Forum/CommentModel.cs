namespace AutoPartsShopAndForum.Services.Data.Forum
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? ParentId { get; set; }

        public CommentModel Parent { get; set; }

        public string CreatorUsername { get; set; }
    }
}
