using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class BookBUS
    {
        #region Avariable
        /// <summary>
        /// Initialize Book DAO
        /// </summary>
        public BookDAO bookDAO = new BookDAO();

        
        #endregion

        #region Method

        /// <summary>
        /// Create object Book
        /// </summary>
        /// <param name="obj">Input object book</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : create is success. False : create isn't success</returns>
        public bool Create(Book obj, ref string error)
        {
            if (obj == null)
            {
                error = "Input book is null";
                return false;
            }

            return bookDAO.Create(obj, ref error);
        }

        public bool Del(int id, ref string error)
        {
            return bookDAO.Del(id, ref error);
        }

        /// <summary>
        /// Get all book 
        /// </summary>
        /// <returns>List book</returns>
        public List<Book> GetAll(ref string error)
        {
            return bookDAO.GetAll(ref error);
        }

        

        /// <summary>
        /// Get all book to DataTable by author ID.
        /// Convert DataRow to property List.
        /// </summary>
        /// <param name="ID">Input author ID.</param>
        /// <returns>Book list after found by author ID</returns>
        public List<Book> GetAllBookByAuthorID(int id, ref string error)
        {
            return bookDAO.GetAllBookByAuthorID(id, ref error);
        }

        /// <summary>
        /// Get all book to DataTable by category ID.
        /// Convert DataRow to property List.
        /// </summary>
        /// <param name="ID">Input category ID</param>
        /// <returns>Book list after found by category  ID</returns>
        public List<Book> GetAllBookByCategoryID(int id, ref string error)
        {
            int o = 0;
            if (!int.TryParse(id.ToString(), out o))
            {
                error = "ID isn't format";
                return null;
            }
            return bookDAO.GetAllBookByCategoryID(id, ref error);
        }

        /// <summary>
        /// Get object book by id
        /// </summary>
        /// <param name="id">Input book id</param>
        /// <param name="error">Notify error when program erorr</param>
        /// <returns>Object book after found by id</returns>
        public Book GetObjectWithID(int id, ref string error)
        {
            int o = 0;
            if (!int.TryParse(id.ToString(), out o))
            {
                error = "ID isn't format";
                return null;
            }

            return bookDAO.GetObjectWithID(id, ref error);
        }
        #endregion
    }
}
