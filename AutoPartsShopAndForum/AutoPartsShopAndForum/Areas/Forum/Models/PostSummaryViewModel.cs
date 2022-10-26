namespace AutoPartsShopAndForum.Areas.Forum.Models
{
    public class PostSummaryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreatorUserName { get; set; }

        public string DateOfCreate { get; set; }

        public int CommentsCount { get; set; }
    }
}