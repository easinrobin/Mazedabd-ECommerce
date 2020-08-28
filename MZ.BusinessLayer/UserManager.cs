using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class UserManager
    {
        public static User GetUserByUserNameNPassword(string userName, string password)
        {
            SqlUserProvider provider = new SqlUserProvider();
            return provider.GetUserByUserNameNPassword(userName, password);
        }
    }
}
