using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IProductGalleryProvider
    {
        List<ProductGallery> GetAllProductGallery();
        ProductGallery GetProductGalleryById(long Id);
        long InsertProductGallery(ProductGallery gallery);
        bool UpdateProductGallery(ProductGallery gallery);
        bool DeleteProductGallery(long Id);
    }
}
