namespace AutoPartsShopAndForum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.Category.MaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Subcategory> SubCategories { get; set; }
    }
}
