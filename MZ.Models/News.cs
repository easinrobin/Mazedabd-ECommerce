using System.ComponentModel.DataAnnotations;

namespace MZ.Models
{
    public class News
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Video Path")]
        public string VideoPath { get; set; }

    }
}
