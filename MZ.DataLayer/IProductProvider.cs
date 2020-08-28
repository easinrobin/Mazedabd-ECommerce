using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IProductProvider
    {
        List<Product> GetAllProduct();
        Product GetProductById(long? Id);
        long InsertProduct(Product product);
        bool UpdateProduct(Product products);
        bool DeleteProduct(long Id);
    }
}
