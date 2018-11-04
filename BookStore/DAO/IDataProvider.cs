using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public   interface IDataProvider<T>
    {
        /// <summary>
        /// Get all object in list.
        /// </summary>
        /// <returns>List of object</returns>
        List<T> GetAll(ref string error);

        /// <summary>
        /// Get object in list by id.
        /// </summary>
        /// <param name="id">Input id of object.</param>
        /// <param name="error"></param>
        /// <returns></returns>
        T GetObjectWithID(int id, ref string error);

        /// <summary>
        /// Create new objetct int list.
        /// </summary>
        /// <param name="obj">Input object to add in list.</param>
        /// <param name="error">Notify error when program erorr.</param>
        /// <returns>True : create is success. False : create isn't success.</returns>
        bool Create(T obj, ref string error);

        /// <summary>
        /// Delete object in list
        /// </summary>
        /// <param name="id">Input object to del in list</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : delete is success. False : delete isn't success</returns>
        bool Del(int id, ref string error);
    }
}
