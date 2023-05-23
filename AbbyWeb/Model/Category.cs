using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(1,100,ErrorMessage ="It should be between 1 and 100")]
        [Display(Name="Display Order")]
        public int DisplayOrder { get; set; }
    }
}
