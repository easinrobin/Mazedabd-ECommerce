using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MZ.Models;
using MZ.Utility;

namespace MZ.DataLayerSql
{
    public class SqlNewsEventsProvider
    {
        #region Image Gallery

        public List<ImageGallery> GetAllImageGallery()
        {
            List<ImageGallery> list = new List<ImageGallery>();
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    list = UtilityManager.DataReaderMapToList<ImageGallery>(dataReader);
                    return list;
                }
                catch (Exception e)
                {
                    UtilityManager.WriteLogError(e.ToString());
                    return list;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public ImageGallery GetImageGalleryById(long id)
        {
            ImageGallery list = new ImageGallery();
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetImageGalleryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list = UtilityManager.DataReaderMap<ImageGallery>(reader);
                    return list;
                }
                catch (Exception e)
                {
                    UtilityManager.WriteLogError(e.ToString());
                    return list;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public long InsertImageGallery(ImageGallery gallery)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var item in gallery.GetType().GetProperties())
                {
                    if (item.Name != "Id")
                    {
                        string name = item.Name;
                        var value = item.GetValue(gallery, null);

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
                    UtilityManager.WriteLogError(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateImageGallery(ImageGallery gallery)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in gallery.GetType().GetProperties())
                {
                    string name = item.Name;
                    var value = item.GetValue(gallery, null);
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
                    UtilityManager.WriteLogError(e.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }

        public bool DeleteImageGallery(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteImageGallery, connection);
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
                    UtilityManager.WriteLogError(e.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

        #endregion

        #region Video Gallery

        public List<VideoGallery> GetAllVideoGallery()
        {
            List<VideoGallery> list = new List<VideoGallery>();
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllVideoGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    list = UtilityManager.DataReaderMapToList<VideoGallery>(dataReader);
                    return list;
                }
                catch (Exception e)
                {
                    UtilityManager.WriteLogError(e.ToString());
                    return list;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public VideoGallery GetVideoGalleryById(long id)
        {
            VideoGallery list = new VideoGallery();
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetVideoGalleryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list = UtilityManager.DataReaderMap<VideoGallery>(reader);
                    return list;
                }
                catch (Exception e)
                {
                    UtilityManager.WriteLogError(e.ToString());
                    return list;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public long InsertVideoGallery(VideoGallery gallery)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertVideoGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var item in gallery.GetType().GetProperties())
                {
                    if (item.Name != "Id")
                    {
                        string name = item.Name;
                        var value = item.GetValue(gallery, null);

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
                    UtilityManager.WriteLogError(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateVideoGallery(VideoGallery gallery)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateVideoGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in gallery.GetType().GetProperties())
                {
                    string name = item.Name;
                    var value = item.GetValue(gallery, null);
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
                    UtilityManager.WriteLogError(e.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }

        public bool DeleteVideoGallery(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteVideoGallery, connection);
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
                    UtilityManager.WriteLogError(e.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

        #endregion
    }
}
