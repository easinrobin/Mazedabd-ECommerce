using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class ProductGallery
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Id")]
        public long ProductId { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image Details")]
        public string ImageDetails { get; set; }


        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
