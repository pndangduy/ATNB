using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public  class UserDAO
    {
        #region Method

        /// <summary>
        /// Login of user
        /// </summary>
        /// <param name="userName">Input Username</param>
        /// <param name="password">Input Password</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : login is success. False : login isn't success</returns>
        public bool Login(string userName, string password, ref string error)
        {
            try
            {
                return DataProvider.Instance.QueryStoreProduce("SP_Login", ref error,
                                                                new SqlParameter("Username", userName),
                                                                new SqlParameter("Password", password));
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
        }
        #endregion
    }

}
