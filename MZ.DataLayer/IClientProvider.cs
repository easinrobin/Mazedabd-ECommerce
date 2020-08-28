using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IClientProvider
    {
        List<OurClient> GetAllClients();
        OurClient GetClientById(long Id);
        long InsertClient(OurClient client);
        bool UpdateClient(OurClient client);
        bool DeleteClient(long Id);
    }
}
