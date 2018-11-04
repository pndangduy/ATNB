using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class UserBUS
    {
        #region Avariable 
        private UserDAO userDAO = new UserDAO();
        #endregion

        #region Method
        /// <summary>
        /// Login of user
        /// </summary>
        /// <param name="userName">Input Username</param>
        /// <param name="password">Input Password</param>
        /// <param name="error">Notify error when program error</param>
        /// <returns>True : login is success. False : login isn't success</returns>
        public bool Login(string username, string password, ref string error)
        {

            if (String.IsNullOrEmpty(username))
            {
                error = "Username is empty";
                return false;
            }

            if (String.IsNullOrEmpty(password))
            {
                error = "Password is empty";
                return false;
            }

            return userDAO.Login(username, password, ref error);
        }
        #endregion
    }
}
