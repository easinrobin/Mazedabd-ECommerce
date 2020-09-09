using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Category Id")]
        [Required(ErrorMessage = "Product Category Id required")]
        public int ProductCategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Price required")]
        public long Price { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Discount Price")]
        public long DiscountPrice { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Display(Name = "Short Details")]
        public string ShortDetails { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
