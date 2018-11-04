using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Book
    {
        /// <summary>
        /// ID of book
        /// </summary>
        public int BookID { get; set; }
        /// <summary>
        /// Title of book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Summary of book
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Category id 
        /// </summary>
        public int CateID { get; set; }
        /// <summary>
        /// Author id 
        /// </summary>
        public int AuthorID { get; set; }
        /// <summary>
        /// Publisher ID
        /// </summary>
        public int PublisherID { get; set; }
        /// <summary>
        /// Price of book
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Quantity of book
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Image Url of book
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// Status active of book
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Constructor of Book no paramater
        /// </summary>
        public Book() { }
        /// <summary>
        /// Constructor of Book 
        /// </summary>
        /// <param name="bookID">ID of book</param>
        /// <param name="title">Title of book</param>
        /// <param name="price">Price of book</param>
        /// <param name="quantity">Quantity of book</param>
        /// <param name="imgUrl">Image url of book</param>
        /// <param name="isActive">Status active of book</param>
        public Book(int bookID, string title, string summary, int cateID, int authorID, int publisherID, double price, int quantity, string imgUrl, bool isActive)
        {
            this.BookID = bookID;
            this.Title = title;
            this.Summary = summary;
            this.CateID = cateID;
            this.AuthorID = authorID;
            this.PublisherID = publisherID;
            this.Price = price;
            this.Quantity = quantity;
            this.ImgUrl = imgUrl;
            this.IsActive = isActive;
        }
    }
}
