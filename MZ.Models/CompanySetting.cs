using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MZ.Models
{
    public class CompanySetting
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo required")]
        public string LogoUrl { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name required")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Moto")]
        [Required(ErrorMessage = "Company Moto required")]
        public string CompanyMoto { get; set; }

        [Display(Name = "Company Address")]
        [Required(ErrorMessage = "Company Address required")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Main Contact No")]
        [Required(ErrorMessage = "Main Contact No required")]
        public string MainContactNo { get; set; }

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Contact No required")]
        public string ContactNo { get; set; }

        [Display(Name = "Email_1")]
        [Required(ErrorMessage = "Email_1 required")]
        public string Email_1 { get; set; }

        [Display(Name = "Email_2")]
        [Required(ErrorMessage = "Email_2 required")]
        public string Email_2 { get; set; }

        [Display(Name = "Map Location")]
        [Required(ErrorMessage = "Map Location required")]
        public string GMapLocation { get; set; }

        [Display(Name = "Facebook Page")]
        [Required(ErrorMessage = "Facebook Page required")]
        public string FacebookPageUrl { get; set; }

        [Display(Name = "Youtube Page")]
        [Required(ErrorMessage = "Youtube Page required")]
        public string YoutubePageUrl { get; set; }

        [Display(Name = "LinkedIn Page")]
        [Required(ErrorMessage = "LinkedIn Page required")]
        public string LinkedInPageUrl { get; set; }

        [Display(Name = "GooglePlus Page")]
        [Required(ErrorMessage = "GooglePlus Page required")]
        public string GooglePlusPageUrl { get; set; }

        [Display(Name = "Twitter Page")]
        [Required(ErrorMessage = "Twitter Page required")]
        public string TwitterPageUrl { get; set; }

        [Display(Name = "Owner Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImgUrl { get; set; }
    }

    [NotMapped]
    public class OwnerImage
    {
        public HttpPostedFileBase File { get; set; }
    }
}
