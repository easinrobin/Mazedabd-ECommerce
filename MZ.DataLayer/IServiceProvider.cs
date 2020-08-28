using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IServiceProvider
    {
        List<OurService> GetAllService();
        OurService GetServiceById(long Id);
        long InsertService(OurService service);
        bool UpdateService(OurService services);
        bool DeleteService(long Id);
    }
}
