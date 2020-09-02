using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class ProductManager
    {
        public static List<Product> GetAllProduct()
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.GetAllProduct();
        }

        public static List<Product> GetProductsBySearchKey(string searchKey)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.GetProductsBySearchKey(searchKey);
        }

        public static Product GetProductById(long? id)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.GetProductById(id);
        }


        public static bool UpdateProduct(Product product)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.UpdateProduct(product);
        }

        public static long InsertProduct(Product product)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.InsertProduct(product);
        }

        public static bool DeleteProduct(long Id)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.DeleteProduct(Id);
        }



        public static List<ProductGallery> GetAllProductGallery()
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.GetAllProductGallery();
        }

        public static List<ProductGallery> GetProductGalleryById(int Id)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.GetAllProductGalleriesByProductId(Id);
        }

        public static bool UpdateProductGallery(ProductGallery gallery)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.UpdateProductGallery(gallery);
        }

        public static long InsertProductGallery(ProductGallery gallery)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.InsertProductGallery(gallery);
        }

        public static bool DeleteProductGallery(long Id)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.DeleteProductGallery(Id);
        }

        public static List<ProductGallery> GetAllProductGalleriesByProductId(long? productId)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.GetAllProductGalleriesByProductId(productId);
        }

        public static ProductGallery GetGalleryById(int Id)
        {
            SqlProductGalleryProvider provider = new SqlProductGalleryProvider();
            return provider.GetGalleryById(Id);
        }

    }
}
