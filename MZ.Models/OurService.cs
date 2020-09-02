using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class OurService
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "Service Name required")]
        public string ServiceName { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
