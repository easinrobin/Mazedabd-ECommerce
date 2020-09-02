using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class CategoryManager
    {
        public static List<ProductCategory> GetAllProductCategory()
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.GetAllProductCategory();
        }

        public static ProductCategory GetProductCategoryById(long Id)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.GetProductCategoryById(Id);
        }

        public static bool UpdateProductCategory(ProductCategory product)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.UpdateProductCategory(product);
        }

        public static long InsertProductCategory(ProductCategory product)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.InsertProductCategory(product);
        }

        public static bool DeleteProductCategory(long Id)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.DeleteProductCategory(Id);
        }

        public static List<Product> GetAllProductsByCategoryId(long categoryId)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.GetAllProductsByCategoryId(categoryId);
        }

        public static List<ProductSubCategory> GetAllProductSubCategory()
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.GetAllProductSubCategory();
        }

        public static List<ProductSubCategory> GetSubCategoryByCategoryId(long id)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.GetSubCategoryByCategoryId(id);
        }

        public static ProductSubCategory GetProductSubCategoryById(long Id)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.GetProductSubCategoryById(Id);
        }

        public static bool UpdateProductSubCategory(ProductSubCategory product)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.UpdateProductSubCategory(product);
        }

        public static long InsertProductSubCategory(ProductSubCategory product)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.InsertProductSubCategory(product);
        }

        public static bool DeleteProductSubCategory(long Id)
        {
            SqlProductCategoryProvider provider = new SqlProductCategoryProvider();
            return provider.DeleteProductSubCategory(Id);
        }

        public static List<Product> GetAllProductsBySubCategoryId(long id)
        {
            SqlProductProvider provider = new SqlProductProvider();
            return provider.GetAllProductsBySubCategoryId(id);
        }
    }
}
