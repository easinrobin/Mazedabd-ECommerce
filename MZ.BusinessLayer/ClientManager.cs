using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    class ClientManager
    {
        public static List<OurClient> GetAllClients()
        {
            SqlClientProvider provider = new SqlClientProvider();
            return provider.GetAllClients();
        }

        public static OurClient GetClientById(long Id)
        {
            SqlClientProvider provider = new SqlClientProvider();
            return provider.GetClientById(Id);
        }

        public static bool UpdateClient(OurClient client)
        {
            SqlClientProvider provider = new SqlClientProvider();
            return provider.UpdateClient(client);
        }

        public static long InsertClient(OurClient client)
        {
            SqlClientProvider provider = new SqlClientProvider();
            return provider.InsertClient(client);
        }

        public static bool DeleteClient(long Id)
        {
            SqlClientProvider provider = new SqlClientProvider();
            return provider.DeleteClient(Id);
        }
    }
}
