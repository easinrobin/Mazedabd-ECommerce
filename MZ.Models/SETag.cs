using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class SETag
    {

        [Key]
        public long id { get; set; }

        [Display(Name = "Page Name")]
        [Required(ErrorMessage = "Page Name required")]
        public string PageName { get; set; }

        [Display(Name = "Metatag")]
        public string Metatag { get; set; }


        [Display(Name = "MetaDesciption")]
        public string MetaDesciption { get; set; }


        [Display(Name = "Canonical")]
        public string Canonical { get; set; }


        [Display(Name = "HrefTag")]
        public string HrefTag { get; set; }


    }
}
