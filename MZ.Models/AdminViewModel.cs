using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MZ.Models
{
    public class AdminViewModel
    {
        public Banner Banner { get; set; }
        public AboutUs AboutUs { get; set; }
        public OurClient Clients { get; set; }
        public List<OurClient> ClientList { get; set; }
        public CompanySetting CompanySetting { get; set; }
        public List<Feedback> FeedbackList { get; set; }
        public OurService Service { get; set; }
        public List<OurService> ServiceList { get; set; }
        public Product Product { get; set; }
        public List<Product> ProductList { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<ProductCategory> ProductCategoryList { get; set; }
        public ProductGallery ProductGallery { get; set; }
        public List<ProductGallery> ProductGalleryList { get; set; }
        public OwnerImage OwnerImage { get; set; }
        public SliderBgImgUrl SliderBgImgUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public HttpPostedFileBase File { get; set; }
    }
}
