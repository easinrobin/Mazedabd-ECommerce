using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface ICompanySettingsProvider
    {
        CompanySetting GetCompanySettings(long Id);
        bool UpdateSettings(CompanySetting setting);
    }
}
