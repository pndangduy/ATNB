using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DTO;
using BUS;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {

        #region Avariable
        /// <summary>
        /// Initialize hard cord for username to display page main when login success
        /// </summary>
        public static string Username = string.Empty;
        /// <summary>
        /// Initialize string error
        /// </summary>
        private string error = string.Empty;
        /// <summary>
        /// Initialize user BUS
        /// </summary>
        private UserBUS userBUS = new UserBUS();
        #endregion

        #region Method

        /// <summary>
        /// Page login.
        /// </summary>
        /// <returns>Pgae login</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// Logout account and set username is empty
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Username = string.Empty;
            return RedirectToAction("Main", "Home");
        }

        /// <summary>
        /// Handle login 
        /// </summary>
        /// <param name="user">Input object user</param>
        /// <returns>Login is success will return Page main</returns>
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                bool isLogin = userBUS.Login(user.UserName, user.Password, ref error);

                if (isLogin)
                {
                    Username = user.UserName;
                    Response.Write("<Script>alert('Đăng nhập thành công')</script>");
                    return RedirectToAction("Main", "Home");
                }
            }
            Response.Write("<Script>alert('Đăng nhập không thành công')</script>");
            return View();
        }

        /// <summary>
        /// Role to page respectively
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Role()
        {
            return RedirectToAction("Index", "Admin", new { Area = "Admin" });
        }
        #endregion
    }
}