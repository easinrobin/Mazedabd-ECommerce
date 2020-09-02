using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]
        [StringLength(20, ErrorMessage = "Must be 3 character long", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile required")]
        [StringLength(13, ErrorMessage = "Enter Valid Mobile Number", MinimumLength = 11)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Enter only numbers")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Message required")]
        public string Message { get; set; }

        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }
    }
}
