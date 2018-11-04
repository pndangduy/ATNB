using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        #region Avariable
        public AuthorBUS authorBUS = new AuthorBUS();
        public CategoryBUS categoryBUS = new CategoryBUS();
        public BookBUS bookBUS = new BookBUS();

        private string error = string.Empty;
        #endregion

        /// <summary>
        /// Get all books 
        /// Set session 'username' by variable username of login
        /// </summary>
        /// <returns>Page contain book list</returns>

        [HttpGet]
        public ActionResult Main()
        {

            //List<BookList> list = new List<BookList>();
            var authorList = authorBUS.GetAll(ref error);

            var bookList = bookBUS.GetAll(ref error);

            var resultList = (from a in authorList
                              join b in bookList
                              on a.AuthorID equals b.AuthorID
                              select new BookList
                              {
                                  BookID = b.BookID,
                                  Title = b.Title,
                                  Image = b.ImgUrl,
                                  AuthorName = a.AuthorName,
                                  Summary = b.Summary,
                                  Price = b.Price
                              }).ToList();


            //foreach (dynamic item in result)
            //{
            //    resultList.Add(new BookList() { BookID = item[0], Title = item[1], Image = item[2], AuthorName = item[3], Summary = item[4], Price = item[5] });
            //}


            Session["Username"] = AccountController.Username;

            return View(resultList);
        }

        /// <summary>
        /// Get all books by author ID 
        /// </summary>
        /// <returns>Page contain book list found by author id</returns>
        [HttpGet]
        public ActionResult GetAllBooksByAuthorID(int authorID)
        {
            var authorList = authorBUS.GetAll(ref error);

            var bookList = bookBUS.GetAllBookByAuthorID(authorID, ref error);

            var resultList = (from a in authorList
                              join b in bookList
                              on a.AuthorID equals b.AuthorID
                              select new BookList
                              {
                                  BookID = b.BookID,
                                  Title = b.Title,
                                  Image = b.ImgUrl,
                                  AuthorName = a.AuthorName,
                                  Summary = b.Summary,
                                  Price = b.Price
                              }).ToList();

            return View(resultList);
        }

        /// <summary>
        /// Get all books by category ID 
        /// </summary>
        /// <returns>Page contain book list found by category id</returns>
        [HttpGet]
        public ActionResult GetAllBooksByCategoryID(int categoryID)
        {
            var authorList = authorBUS.GetAll(ref error);

            var bookList = bookBUS.GetAllBookByCategoryID(categoryID, ref error);

            var resultList = (from a in authorList
                              join b in bookList
                              on a.AuthorID equals b.AuthorID
                              select new BookList
                              {
                                  BookID = b.BookID,
                                  Title = b.Title,
                                  Image = b.ImgUrl,
                                  AuthorName = a.AuthorName,
                                  Summary = b.Summary,
                                  Price = b.Price
                              }).ToList();

            return View(resultList);
        }

        /// <summary>
        /// Get list author
        /// </summary>
        /// <returns>Partial view contain author list</returns>
        [HttpGet]
        public PartialViewResult GetAllAuthor()
        {
            return PartialView("GetAllAuthor", authorBUS.GetAll(ref error));
        }

        /// <summary>            
        /// Get list category
        /// </summary>
        /// <returns>Partial view contain category list</returns>
        [HttpGet]
        public PartialViewResult GetAllCategory()
        {
            return PartialView("GetAllCategory", categoryBUS.GetAll(ref error));
        }
    }
}