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
    public  class BookDAO:IDataProvider<Book>
    {
        #region Function
        /// <summary>
        /// Get all book to DataTable.
        /// Convert DataRow to property List.
        /// </summary>
        /// <returns>Book list.</returns>
        public List<Book> GetAll(ref string error)
        {
            List<Book> bookList = new List<Book>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllBook", ref error).Rows)
                {
                    int id = (int)row[0];
                    string title = (string)row[1];
                    int cateID = (int)row[2];
                    int pubID = (int)row[3];
                    int authorID = (int)row[4];
                    string summary = (string)row[5];
                    string image = (string)row[6];
                    double price = Double.Parse(String.Format("{0:N0}", row[7]));
                    int quantity = (int)row[8];
                    bool isActive = (bool)row[11];
                    bookList.Add(new Book(id, title, summary, cateID, authorID, pubID, price, quantity, image, isActive));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return bookList;
        }

        /// <summary>
        /// Get all book to DataTable by author ID.
        /// Convert DataRow to property List.
        /// </summary>
        /// <param name="ID">Input author ID.</param>
        /// <returns>Book list after found by author ID</returns>
        public List<Book> GetAllBookByAuthorID(int ID, ref string error)
        {
            List<Book> bookList = new List<Book>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllBookByAuthorID", ref error, new SqlParameter("AuthorID", ID)).Rows)
                {
                    int id = (int)row[0];
                    string title = (string)row[1];
                    int cateID = (int)row[2];
                    int pubID = (int)row[3];
                    int authorID = (int)row[4];
                    string summary = (string)row[5];
                    string image = (string)row[6];
                    double price = Double.Parse(String.Format("{0:N0}", row[7]));
                    int quantity = (int)row[8];
                    bool isActive = (bool)row[11];
                    bookList.Add(new Book(id, title, summary, cateID, authorID, pubID, price, quantity, image, isActive));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return bookList;
        }

        /// <summary>
        /// Get all book to DataTable by category ID.
        /// Convert DataRow to property List.
        /// </summary>
        /// <param name="ID">Input category ID</param>
        /// <returns>Book list after found by category  ID</returns>
        public List<Book> GetAllBookByCategoryID(int ID, ref string error)
        {
            List<Book> bookList = new List<Book>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllBookByCategoryID", ref error, new SqlParameter("CategoryID", ID)).Rows)
                {
                    int id = (int)row[0];
                    string title = (string)row[1];
                    int cateID = (int)row[2];
                    int pubID = (int)row[3];
                    int authorID = (int)row[4];
                    string summary = (string)row[5];
                    string image = (string)row[6];
                    double price = Double.Parse(String.Format("{0:N0}", row[7]));
                    int quantity = (int)row[8];
                    bool isActive = (bool)row[11];
                    bookList.Add(new Book(id, title, summary, cateID, authorID, pubID, price, quantity, image, isActive));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return bookList;
        }

        /// <summary>
        /// Find object book in book list by book id.
        /// </summary>
        /// <param name="id">ID of book</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>Object book after found in book list.</returns>
        public Book GetObjectWithID(int id, ref string error)
        {
            return null;
        }

        /// <summary>
        /// Create book.
        /// </summary>
        /// <param name="obj">Input object book to create new.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : create is success. False : create isn't success.</returns>
        public bool Create(Book obj, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("SP_CreateBook", ref error,
                                                         new SqlParameter("Title", obj.Title),
                                                         new SqlParameter("Summary", obj.Summary),
                                                         new SqlParameter("CateID", obj.CateID),
                                                         new SqlParameter("PubID", obj.PublisherID),
                                                         new SqlParameter("AuthorID", obj.AuthorID),
                                                         new SqlParameter("Price", obj.Price),
                                                         new SqlParameter("Quantity", obj.Quantity),
                                                         new SqlParameter("IsActive", obj.IsActive),
                                                         new SqlParameter("ImgUrl", obj.ImgUrl));
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Get object book want remove by book id.
        /// Remove object book found in book list.
        /// </summary>
        /// <param name="id">Input id of book.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : delete is success. False : delete isn't success.</returns>
        public bool Del(int id, ref string error)
        {
            //try
            //{
            //    Book book = GetObjectWithID(id, ref error);
            //    bookList.Remove(book);
            //}
            //catch (Exception ex)
            //{
            //    error = ex.Message;
            //    return false;
            //}
            return true;
        }

        #endregion
    }
}
