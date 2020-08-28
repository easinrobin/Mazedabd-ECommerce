using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IProductCategoryProvider
    {
        List<ProductCategory> GetAllProductCategory();
        ProductCategory GetProductCategoryById(long Id);
        long InsertProductCategory(ProductCategory category);
        bool UpdateProductCategory(ProductCategory category);
        bool DeleteProductCategory(long Id);

    }
}
