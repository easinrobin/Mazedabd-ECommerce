using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZ.BusinessLayer
{
    class CompanySettingsManager
    {
        public static CompanySetting GetCompanySettings(long Id)
        {
            SqlCompanySettingsProvider provider = new SqlCompanySettingsProvider();
            return provider.GetCompanySettings(Id);
        }

        public static bool UpdateSettings(CompanySetting setting)
        {
            SqlCompanySettingsProvider provider = new SqlCompanySettingsProvider();
            return provider.UpdateSettings(setting);
        }
        public static CompanySetting GetCompanySetting()
        {
            SqlCompanySettingsProvider provider = new SqlCompanySettingsProvider();
            return provider.GetCompanySetting();
        }
    }
}
