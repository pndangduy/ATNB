using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Author
    {
        /// <summary>
        /// ID of Author
        /// </summary>
        public int AuthorID { get; set; }
        /// <summary>
        /// Name of Author
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// History of Author
        /// </summary>
        public string History { get; set; }

        /// <summary>
        /// Constructor of Author
        /// </summary>
        /// <param name="authorID">ID of author</param>
        /// <param name="authorName">Name of author</param>
        /// <param name="history">History of author</param>
        public Author(int authorID, string authorName, string history)
        {
            this.AuthorID = authorID;
            this.AuthorName = authorName;
            this.History = history;
        }
    }
}
