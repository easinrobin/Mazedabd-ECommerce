using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface ISeoProvider
    {
        List<SETag> GetAllSeos();
        SETag GetSeoByPageName(string PageName);
        SETag GetSeoById(int id);
        long InsertSeo(SETag seo);
        bool UpdateSeo(SETag seo);
        bool DeleteSeo(long id);
    }
}
