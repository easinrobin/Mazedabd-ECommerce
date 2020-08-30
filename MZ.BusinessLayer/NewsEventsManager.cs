using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class NewsEventsManager
    {
        #region Image Gallery

        public static List<ImageGallery> GetAllImageGallery()
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.GetAllImageGallery();
        }

        public static ImageGallery GetImageGalleryById(long id)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.GetImageGalleryById(id);
        }

        public static bool UpdateImageGallery(ImageGallery gallery)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.UpdateImageGallery(gallery);
        }

        public static long InsertImageGallery(ImageGallery gallery)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.InsertImageGallery(gallery);
        }

        public static bool DeleteImageGallery(long id)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.DeleteImageGallery(id);
        }

        #endregion

        #region Video Gallery

        public static List<VideoGallery> GetAllVideoGallery()
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.GetAllVideoGallery();
        }

        public static VideoGallery GetVideoGalleryById(long id)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.GetVideoGalleryById(id);
        }

        public static bool UpdateVideoGallery(VideoGallery gallery)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.UpdateVideoGallery(gallery);
        }

        public static long InsertVideoGallery(VideoGallery gallery)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.InsertVideoGallery(gallery);
        }

        public static bool DeleteVideoGallery(long id)
        {
            SqlNewsEventsProvider provider = new SqlNewsEventsProvider();
            return provider.DeleteVideoGallery(id);
        }

        #endregion
    }
}
