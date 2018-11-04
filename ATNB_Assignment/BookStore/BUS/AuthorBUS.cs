using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class AuthorBUS
    {
        #region Avariable
        /// <summary>
        /// Initialize new author DAL
        /// </summary>
        private AuthorDAO authorDAO = new AuthorDAO();

        #endregion

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
            if (String.IsNullOrEmpty(authorID.ToString()) ||
                String.IsNullOrEmpty(authorName) ||
                String.IsNullOrEmpty(history))
            {
                error = "Input isn't empty";
                return false;
            }

            return authorDAO.EditAuthor(authorID, authorName, history, ref error);
        }

        /// <summary>
        /// Get all author 
        /// </summary>
        /// <returns>List author</returns>
        public List<Author> GetAll(ref string error)
        {
            return authorDAO.GetAll(ref error);
        }


        /// <summary>
        /// Find object author in author list by input author id
        /// </summary>
        /// <param name="id">Input author id</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>Object author after found in author list</returns>
        public Author GetObjectWithID(int id, ref string error)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                error = "Author id is empty";
                return null;
            }

            int o;
            if (!int.TryParse(id.ToString(), out o))
            {
                error = "Author ID isn't format";
                return null;
            }

            return authorDAO.GetObjectWithID(id, ref error);
        }

        /// <summary>
        /// Delete one object author in author list.
        /// </summary>
        /// <param name="authorID">Input id of author.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : delete is success. False : delete isn't success.</returns>
        public bool Del(int id, ref string error)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                error = "Author id is empty";
                return false;
            }

            return authorDAO.Del(id, ref error);
        }

        public bool Create(Author obj, ref string error)
        {
            if (obj == null)
            {
                error = "Object author input is null";
                return false;
            }

            return authorDAO.Create(obj, ref error);
        }
    }
}
