using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class ServiceManager
    {
        public static List<OurService> GetAllService()
        {
            SqlServiceProvider provider = new SqlServiceProvider();
            return provider.GetAllService();
        }

        public static OurService GetServiceById(long Id)
        {
            SqlServiceProvider provider = new SqlServiceProvider();
            return provider.GetServiceById(Id);
        }

        public static bool UpdateService(OurService service)
        {
            SqlServiceProvider provider = new SqlServiceProvider();
            return provider.UpdateService(service);
        }

        public static long InsertService(OurService service)
        {
            SqlServiceProvider provider = new SqlServiceProvider();
            return provider.InsertService(service);
        }

        public static bool DeleteService(long Id)
        {
            SqlServiceProvider provider = new SqlServiceProvider();
            return provider.DeleteService(Id);
        }
    }
}
