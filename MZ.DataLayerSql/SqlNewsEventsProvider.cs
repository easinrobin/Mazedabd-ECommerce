using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MZ.DataLayer;
using MZ.Models;
using MZ.Utility;

namespace MZ.DataLayerSql
{
    public class SqlNewsEventsProvider : INewsProvider
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

        #region News Events

        public List<News> GetAllNews()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllNews, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<News> newsList = new List<News>();
                    newsList = UtilityManager.DataReaderMapToList<News>(dataReader);
                    return newsList;
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


        public News GetNewsById(long? id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetNewsById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    News news = new News();
                    news = UtilityManager.DataReaderMap<News>(reader);
                    return news;
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

        public long InsertNews(News news)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertNews, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var newsInfo in news.GetType().GetProperties())
                {
                    if (newsInfo.Name != "Id")
                    {
                        string name = newsInfo.Name;
                        var value = newsInfo.GetValue(news, null);

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
                    throw new Exception("Execption Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }


        public bool UpdateNews(News news)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateNews, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var newsInfo in news.GetType().GetProperties())
                {
                    string name = newsInfo.Name;
                    var value = newsInfo.GetValue(news, null);
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
        
        public bool DeleteNews(long id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteNews, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

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

        #endregion
    }
}
