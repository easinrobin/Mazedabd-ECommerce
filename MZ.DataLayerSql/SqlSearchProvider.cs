using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MZ.Models;
using MZ.Utility;

namespace MZ.DataLayerSql
{
    public class SqlSearchProvider
    {
        //public List<ProductSearchResult> GetAllResults(string searchKey)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        List<ProductSearchResult> list = new List<ProductSearchResult>();
        //        SqlCommand command = new SqlCommand(StoreProcedure.GetSearchResults, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@searchKey", searchKey));

        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader dataReader = command.ExecuteReader();
        //            list = UtilityManager.DataReaderMapToList<ProductSearchResult>(dataReader);
        //            return list;
        //        }
        //        catch (Exception e)
        //        {
        //           UtilityManager.WriteLogError(e.ToString());
        //           return list;
        //        }

        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
    }
}
