using BUS;
using DTO;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
  
        public class BookController : Controller
        {
            #region Avariable 
            /// <summary>
            /// Initialize book BUS
            /// </summary>
            public BookBUS bookBUS = new BookBUS();
            /// <summary>
            /// Initialize author BUS
            /// </summary>
            public AuthorBUS authorBUS = new AuthorBUS();
            /// <summary>
            /// Initialize category BUS
            /// </summary>
            public CategoryBUS categoryBUS = new CategoryBUS();
            /// <summary>
            /// Initialize publisher BUS
            /// </summary>
            public PublisherBUS publisherBUS = new PublisherBUS();
            /// <summary>
            /// String notify error
            /// </summary>
            private string error = "";
            #endregion

            #region Method
            /// <summary>
            /// Get all book to page
            /// </summary>
            /// <returns>Page display info</returns>
            public ActionResult GetAllBook()
            {
                return View(bookBUS.GetAll(ref error));
            }


            /// <summary>
            /// Get all books
            /// </summary>
            /// <returns>Book list type json</returns>
            [HttpGet]
            public JsonResult GetBooks()
            {
                var books = bookBUS.GetAll(ref error);

                var jsonData = new
                {
                    data = books,
                };

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            /// <summary>
            /// Load select list to viewbag
            /// </summary>
            /// <returns>Page create book</returns>
            [HttpGet]
            public ActionResult CreateBook()
            {
                ViewBag.AuthorList = new SelectList(GetAllAuthor(), "AuthorID", "AuthorName");

                ViewBag.CateList = new SelectList(GetAllCategory(), "CateID", "CateName");

                ViewBag.PublisherList = new SelectList(GetAllPublisher(), "PublisherID", "PublisherName");

                return View();
            }

            [HttpPost]
            public ActionResult CreateBook(Book book, HttpPostedFileBase file = null)
            {
                if (ModelState.IsValid)
                {
                    book.AuthorID = int.Parse(Request.Form["author-name"].ToString());

                    book.CateID = int.Parse(Request.Form["category-name"].ToString());

                    book.PublisherID = int.Parse(Request.Form["publisher-name"].ToString());

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/Assets/"), fileName);

                        file.SaveAs(path);

                        book.ImgUrl = fileName;
                    }


                    bool isCreate = bookBUS.Create(book, ref error);
                    if (!isCreate)
                    {
                        Response.Write("<script>alert('Thêm không thành công')</script>");
                    }

                    Response.Write($"<script>alert('Thêm thành công. Lỗi : {error}')</script>");
                    ModelState.Clear();
                }
                return CreateBook();
            }

            /// <summary>
            /// Get all author 
            /// </summary>
            /// <returns>Author list</returns>
            private List<Author> GetAllAuthor()
            {
                return authorBUS.GetAll(ref error);
            }

            /// <summary>
            /// Get all publisher 
            /// </summary>
            /// <returns>Publisher list</returns>
            private List<Publisher> GetAllPublisher()
            {
                return publisherBUS.GetAll(ref error);
            }

            /// <summary>
            /// Get all category 
            /// </summary>
            /// <returns>Category list</returns>
            private List<Category> GetAllCategory()
            {
                return categoryBUS.GetAll(ref error);
            }
            #endregion
        }
    }