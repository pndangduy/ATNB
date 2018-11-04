using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CategoryBUS
    {
        #region Avariable
        /// <summary>
        /// Initialize new author DAL
        /// </summary>
        private CategoryDAO categoryrDAO = new CategoryDAO();

        #endregion

        /// <summary>
        ///  Edit infor of object author.
        /// </summary>
        /// <param name="authorID">Input id of author.</param>
        /// <param name="authorName">Input name of author.</param>
        /// <param name="history">Input history of author.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : edit is success. False : edit isn't success.</returns>
        public bool EditAuthor(int ID, string Name, string Description, ref string error)
        {
            if (String.IsNullOrEmpty(ID.ToString()) ||
                String.IsNullOrEmpty(Name) ||
                String.IsNullOrEmpty(Description))
            {
                error = "Input isn't empty";
                return false;
            }

            return categoryrDAO.EditCategory(ID, Name, Description, ref error);
        }

        /// <summary>
        /// Get all author 
        /// </summary>
        /// <returns>List author</returns>
        public List<Category> GetAll(ref string error)
        {
            return categoryrDAO.GetAll(ref error);
        }


        /// <summary>
        /// Find object author in author list by input author id
        /// </summary>
        /// <param name="id">Input author id</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>Object author after found in author list</returns>
        public Category GetObjectWithID(int id, ref string error)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                error = "Category id is empty";
                return null;
            }

            int o;
            if (!int.TryParse(id.ToString(), out o))
            {
                error = "Category ID isn't format";
                return null;
            }

            return categoryrDAO.GetObjectWithID(id, ref error);
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
                error = "Category id is empty";
                return false;
            }

            return categoryrDAO.Del(id, ref error);
        }

        public bool Create(Category obj, ref string error)
        {
            if (obj == null)
            {
                error = "Object Category input is null";
                return false;
            }

            return categoryrDAO.Create(obj, ref error);
        }
    }
}
