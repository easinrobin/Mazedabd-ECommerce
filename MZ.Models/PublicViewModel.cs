using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.Models
{
    class PublicViewModel
    {
        public List<Banner> Banners { get; set; }
        public AboutUs AboutUs { get; set; }
        public OurClient Clients { get; set; }
        public List<OurClient> OurClients { get; set; }
        public CompanySetting CompanySetting { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductSubCategory> ProductSubCategories { get; set; }
        public List<OurService> OurServices { get; set; }
        public List<Product> Products { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductSubCategory ProductSubCategory { get; set; }
        public Product Product { get; set; }
        public List<ProductGallery> ProductGalleries { get; set; }
        public Feedback Feedback { get; set; }
    }
}
