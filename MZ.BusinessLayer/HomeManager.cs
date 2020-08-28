using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static OurClientsBanner GetClientsBanner(long Id)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.GetClientsBanner(Id);
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

        public static bool UpdateClientsBanner(OurClientsBanner clientsBanner)
        {
            SqlHomeProvider provider = new SqlHomeProvider();
            return provider.UpdateClientsBanner(clientsBanner);
        }

        #endregion
    }
}
