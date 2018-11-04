using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookList
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
        /// Image of book
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Author name of book
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Summary of book
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Price of book
        /// </summary>
        public double Price { get; set; }
    }
}
