using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class SearchManager
    {
        public static List<SearchItem> GetSearchResults(string searchKey)
        {
            List<SearchItem> results = new List<SearchItem>();

            #region Products 
            var products = ProductManager.GetProductsBySearchKey(searchKey);
            foreach (var product in products)
            {
                SearchItem ps = new SearchItem();
                ps.Title = product.ProductName;
                ps.Description = product.Description;
                ps.ShortDetails = product.ShortDetails;
                ps.ImageUrl = product.ImageUrl;
                ps.Link = "/Home/ProductDetails?id=" + product.Id;

                results.Add(ps);

            }
            #endregion

            #region News

            var news = NewsEventsManager.GetNewsBySearchkey(searchKey);

            foreach (var nw in news)
            {
                SearchItem ps = new SearchItem();
                ps.Title = nw.Title;
                ps.Description = nw.Description;
                ps.ShortDetails = nw.ShortDescription;
                ps.ImageUrl = nw.ImagePath;
                ps.Link = "/Home/News?newsId=" + nw.Id;

                results.Add(ps);

            }
            return results;

            #endregion

        }
    }
}
