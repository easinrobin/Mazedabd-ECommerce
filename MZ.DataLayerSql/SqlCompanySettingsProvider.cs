using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.DataLayer;
using MZ.Models;
using MZ.Utility;

namespace MZ.DataLayerSql
{
    public class SqlCompanySettingsProvider : ICompanySettingsProvider
    {
        public CompanySetting GetCompanySettings(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetCompanySetting, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    CompanySetting client = new CompanySetting();
                    client = UtilityManager.DataReaderMap<CompanySetting>(reader);
                    return client;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public CompanySetting GetCompanySetting()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetCompanySetting, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    CompanySetting client = new CompanySetting();
                    client = UtilityManager.DataReaderMap<CompanySetting>(reader);
                    return client;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public bool UpdateSettings(CompanySetting setting)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateCompanySettings, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var settings in setting.GetType().GetProperties())
                {
                    string name = settings.Name;
                    var value = settings.GetValue(setting, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isUpdate = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }
    }
}
