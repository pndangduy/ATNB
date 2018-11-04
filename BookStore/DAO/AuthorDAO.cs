using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public  class AuthorDAO:IDataProvider<Author>
    {
        /// <summary>
        ///  Edit infor of object author.
        /// </summary>
        /// <param name="authorID">Input id of author.</param>
        /// <param name="authorName">Input name of author.</param>
        /// <param name="history">Input history of author.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : edit is success. False : edit isn't success.</returns>
        public bool EditAuthor(int authorID, string authorName, string history, ref string error)
        {
            try
            {
                var author = GetObjectWithID(authorID, ref error);
                author.AuthorName = authorName;
                author.History = history;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Convert DataRow to object author
        /// Add object author to list
        /// </summary>
        /// <returns>List author list</returns>
        public List<Author> GetAll(ref string error)
        {
            List<Author> authorList = new List<Author>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllAuthor", ref error).Rows)
                {
                    authorList.Add(new Author((int)row[0], (string)row[1], (string)row[2]));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return authorList;
        }

        /// <summary>
        /// Find one object author in author list by input author id.
        /// </summary>
        /// <param name="authorID">Input author id.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>Object author after found in author list.</returns>
        public Author GetObjectWithID(int id, ref string error)
        {
            try
            {
                var dataTable = DataProvider.Instance.StoreProduceDataTable("SP_GetAuthorByID", ref error,
                                                                            new SqlParameter("AuthorID", id));

                foreach (DataRow row in dataTable.Rows)
                    return new Author((int)row[0], (string)row[1], (string)row[2]);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return null;
        }

        /// <summary>
        /// Create new object author to author list.
        /// </summary>
        /// <param name="author">Input author.</param>
        /// <param name="error">Error notify when program error.</param>
        /// <returns>True : add author is success. False : add author isn't success.</returns>
        public bool Create(Author obj, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("", ref error, null);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Delete one object author in author list.
        /// </summary>
        /// <param name="authorID">Input id of author.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : delete is success. False : delete isn't success.</returns>
        public bool Del(int id, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("", ref error);
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return false;
        }
    }
}
