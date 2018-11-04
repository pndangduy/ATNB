using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class CategoryDAO:IDataProvider<Category>
    {
        /// <summary>
        ///  Edit infor of object author.
        /// </summary>
        /// <param name="authorID">Input id of author.</param>
        /// <param name="authorName">Input name of author.</param>
        /// <param name="history">Input history of author.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>True : edit is success. False : edit isn't success.</returns>
        public bool EditCategory(int ID, string Name, string Description, ref string error)
        {
            try
            {
                var category = GetObjectWithID(ID, ref error);
                category.CateName = Name;
                category.Description = Description;
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
        public List<Category> GetAll(ref string error)
        {
            List<Category> cateList = new List<Category>();

            try
            {
                foreach (DataRow row in DataProvider.Instance.StoreProduceDataTable("dbo.SP_GetAllCategory", ref error).Rows)
                {
                    cateList.Add(new Category((int)row[0], (string)row[1], (string)row[2]));
                }
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }

            return cateList;
        }

        /// <summary>
        /// Find one object author in author list by input author id.
        /// </summary>
        /// <param name="authorID">Input author id.</param>
        /// <param name="error">Notify error when program error.</param>
        /// <returns>Object author after found in author list.</returns>
        public Category GetObjectWithID(int id, ref string error)
        {
            try
            {
                var dataTable = DataProvider.Instance.StoreProduceDataTable("SP_GetAllCategoryByID", ref error,
                                                                            new SqlParameter("CateID", id));

                foreach (DataRow row in dataTable.Rows)
                    return new Category((int)row[0], (string)row[1], (string)row[2]);
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
        public bool Create(Category obj, ref string error)
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
