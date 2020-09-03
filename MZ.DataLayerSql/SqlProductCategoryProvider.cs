using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MZ.DataLayer;
using MZ.Models;
using MZ.Utility;

namespace MZ.DataLayerSql
{
    public class SqlProductCategoryProvider : IProductCategoryProvider
    {
        public List<ProductCategory> GetAllProductCategory()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProductCategory, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<ProductCategory> categoryList = new List<ProductCategory>();
                    categoryList = UtilityManager.DataReaderMapToList<ProductCategory>(dataReader);
                    return categoryList;
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

        public ProductCategory GetProductCategoryById(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetProductCategoryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ProductCategory category = new ProductCategory();
                    category = UtilityManager.DataReaderMap<ProductCategory>(reader);
                    return category;
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

        public long InsertProductCategory(ProductCategory category)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertProductCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var item in category.GetType().GetProperties())
                {
                    if (item.Name != "Id")
                    {
                        string name = item.Name;
                        var value = item.GetValue(category, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@Id"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateProductCategory(ProductCategory category)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateProductCategory, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in category.GetType().GetProperties())
                {
                    string name = item.Name;
                    var value = item.GetValue(category, null);
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

        public bool DeleteProductCategory(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteProductCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

        public List<ProductSubCategory> GetAllProductSubCategory()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProductSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<ProductSubCategory> categoryList = new List<ProductSubCategory>();
                    categoryList = UtilityManager.DataReaderMapToList<ProductSubCategory>(dataReader);
                    return categoryList;
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

        public ProductSubCategory GetProductSubCategoryById(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetProductSubCategoryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ProductSubCategory category = new ProductSubCategory();
                    category = UtilityManager.DataReaderMap<ProductSubCategory>(reader);
                    return category;
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

        public List<ProductSubCategory> GetSubCategoryByCategoryId(long id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetSubCategoryByCategoryId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryId", id));

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<ProductSubCategory> categoryList = new List<ProductSubCategory>();
                    categoryList = UtilityManager.DataReaderMapToList<ProductSubCategory>(dataReader);
                    return categoryList;
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

        public long InsertProductSubCategory(ProductSubCategory category)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertProductSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var item in category.GetType().GetProperties())
                {
                    if (item.Name != "Id")
                    {
                        string name = item.Name;
                        var value = item.GetValue(category, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@Id"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateProductSubCategory(ProductSubCategory category)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateProductSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in category.GetType().GetProperties())
                {
                    string name = item.Name;
                    var value = item.GetValue(category, null);
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

        public bool DeleteProductSubCategory(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteProductSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }
    }
}
