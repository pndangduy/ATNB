using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;

namespace BookStore.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        #region Avariable 
        /// <summary>
        /// Initialize author BUS
        /// </summary>
        private AuthorBUS authorBUS = new AuthorBUS();
        /// <summary>
        /// String notify error
        /// </summary>
        private string error = "";
        #endregion

        #region Method
        /// <summary>
        /// Get all author to page
        /// </summary>
        /// <returns>Page display all author</returns>
        public ActionResult GetAllAuthor()
        {
            return View();
        }

        /// <summary>
        /// Get all author
        /// </summary>
        /// <returns>Author list type json</returns>
        [HttpGet]
        public JsonResult GetAuthors()
        {
            var authors = authorBUS.GetAll(ref error);
            var jsonData = new
            {
                data = authors
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Page create author
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        /// <summary>
        /// Create infor author 
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                bool isCreate = authorBUS.Create(author, ref error);
                if (isCreate)
                {
                    Response.Write("<script>alert('Thêm thành công')</script>");

                    return View();
                }
            }

            Response.Write("<script>alert('Thêm thành công')</script>");
            return View();
        }

        /// <summary>
        /// Load detail of object author found by author id
        /// </summary>
        /// <param name="id">Input author id</param>
        /// <returns>Page contain object author after found</returns>
        [HttpGet]
        public ActionResult DetailAuthor(int id)
        {
            return View(authorBUS.GetObjectWithID(id, ref error));
        }
        #endregion
    }
}