using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Threading.Tasks;

namespace DAO
{
   public class PublisherDAO:IDataProvider<Publisher>
    {
        #region Function
        /// <summary>
        /// Create new publisher
        /// </summary>
        /// <param name="obj">Input object publisher</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : create is success. False : create isn't success</returns>
        public bool Create(Publisher obj, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("SP_CreatePublisher", ref error,
                                                                new SqlParameter("PublisherName", obj.PublisherName),
                                                                new SqlParameter("Description", obj.Description));
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Delete object publisher by publisher id
        /// </summary>
        /// <param name="id">Input publisher ID</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : delete is success. False : delete isn't success</returns>
        public bool Del(int id, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("SP_DeletePublisher", ref error,
                                                                new SqlParameter("PublisherID", id));
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return false;
        }
        public bool EditPublisher(int PubID, string PubName, string Description, ref string error)
        {
            try
            {
                var publisher = GetObjectWithID(PubID, ref error);
                publisher.PublisherName = PubName;
                publisher.Description = Description;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get all publisher
        /// </summary>
        /// <returns>Publisher list</returns>
        public List<Publisher> GetAll(ref string error)
        {
            List<Publisher> publisherList = new List<Publisher>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllPublisher", ref error, null).Rows)
                {
                    publisherList.Add(new Publisher((int)row[0], (string)row[1], (string)row[2]));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return publisherList;
        }

        /// <summary>
        /// Get object publisher by publisher ID
        /// </summary>
        /// <param name="id">Input publisher ID</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>Object publisher after found by publisher id</returns>
        public Publisher GetObjectWithID(int id, ref string error)
        {

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("SP_GetAllPublisherByID", ref error, new SqlParameter("PublisherID", id)).Rows)
                {
                    return new Publisher((int)row[0], (string)row[1], (string)row[2]);
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return null;
        }
        #endregion
    }
}
