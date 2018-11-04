using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        /// <summary>
        /// UserName of User
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password of User
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gmail of User
        /// </summary>
        public string Gmail { get; set; }
        /// <summary>
        /// Status active of User
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Constructor of User
        /// </summary>
        public User() { }
        /// <summary>
        /// Constructor of User
        /// </summary>
        /// <param name="userName">Username of user</param>
        /// <param name="password">Password of user</param>
        /// <param name="gmail">Gmail of user</param>
        /// <param name="isActive">Status active of user</param>
        public User(string userName, string password, string gmail, bool isActive)
        {
            this.UserName = userName;
            this.Password = password;
            this.Gmail = gmail;
            this.IsActive = isActive;
        }
    }
}
