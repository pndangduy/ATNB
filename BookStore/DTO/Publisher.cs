using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class Publisher
    {
        /// <summary>
        /// ID of publisher.
        /// </summary>
        public int PublisherID { get; set; }
        /// <summary>
        /// Name of publisher.
        /// </summary>
        public string PublisherName { get; set; }
        /// <summary>
        /// Description publisher.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Constructor of publisher.
        /// </summary>
        public Publisher() { }
        /// <summary>
        /// Constructor of publisher.
        /// </summary>
        /// <param name="publisherID">ID of publisher.</param>
        /// <param name="publisherName">Name of publisher.</param>
        /// <param name="description">Description.</param>
        public Publisher(int publisherID, string publisherName, string description)
        {
            this.PublisherID = publisherID;
            this.PublisherName = publisherName;
            this.Description = description;
        }
    }
}
