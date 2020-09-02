using System.Collections.Generic;

namespace MZ.Models
{
    public class PublicViewModel
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
        public ImageGallery ImageGallery { get; set; }
        public List<ImageGallery> ImageGalleries { get; set; }
        public VideoGallery VideoGallery { get; set; }
        public List<VideoGallery> VideoGalleries { get; set; }
        public Feedback Feedback { get; set; }
        public Search Search { get; set; }
        public List<SearchItem> SearchResults { get; set; }
        public News News { get; set; }
        public List<News> NewsList { get; set; }
    }
}
