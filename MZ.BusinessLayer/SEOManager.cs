using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class SEOManager
    {
        public static List<SETag> GetAllSeo()
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.GetAllSeo();
        }

        public static SETag GetSeoByPageName(string PageName)
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.GetSeoByPageName(PageName);
        }

        public static SETag GetSeoById(int id)
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.GetSeoById(id);
        }

        public static bool UpdateSeo(SETag seo)
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.UpdateSeo(seo);
        }

        public static long InsertSeo(SETag seo)
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.InsertSeo(seo);
        }

        public static bool DeleteSeo(long id)
        {
            SqlSeoProvider provider = new SqlSeoProvider();
            return provider.DeleteSeo(id);
        }

    }
}
