using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class HomeManager
    {
        #region GetBanner

        public static Banner GetBannerDetails(long bannerId)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.GetBannerDetails(bannerId);
        }

        public static List<Banner> GetAllBanners()
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.GetAllBanners();
        }

        public static bool DeleteBanner(long Id)
        {
            SqlHomeProvider sqlClientProvider = new SqlHomeProvider();
            var isDelete = sqlClientProvider.DeleteBanner(Id);
            return isDelete;
        }

        public static AboutUs GetAboutUs(long Id)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.GetAboutUs(Id);
        }

        #endregion

        #region SetBanner

        public static long InsertBanner(Banner banner)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.InsertBanner(banner);
        }

        public static bool UpdateBanner(Banner banner)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.UpdateBanner(banner);
        }

        public static bool UpdateAbout(AboutUs aboutUs)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.UpdateAbout(aboutUs);
        }

        #endregion
    }
}
