using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IHomeProvider
    {
        Banner GetBannerDetails(long bannerId);
        List<Banner> GetAllBanners();
        AboutUs GetAboutUs(long Id);
        long InsertBanner(Banner banner);
        bool UpdateBanner(Banner banner);
        bool DeleteBanner(long Id);
        bool UpdateAbout(AboutUs aboutUs);
    }
}
