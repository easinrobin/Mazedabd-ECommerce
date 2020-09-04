using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class ImageGallery
    {
        public long Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title required")]
        public string ImageTitle { get; set; }
        
        [Required(ErrorMessage = "Image required")]
        public string ImagePath { get; set; }

        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
