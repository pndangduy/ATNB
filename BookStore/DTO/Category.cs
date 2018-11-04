using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Category
    {
        /// <summary>
        /// ID of category
        /// </summary>
        public int CateID { get; set; }
        /// <summary>
        /// Name of category
        /// </summary>
        public string CateName { get; set; }
        /// <summary>
        /// Description category
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Constructor of category
        /// </summary>
        public Category() { }
        /// <summary>
        /// Constructor of category
        /// </summary>
        /// <param name="cateID">ID of category</param>
        /// <param name="cateName">Name of category</param>
        /// <param name="description">Description category</param>
        public Category(int cateID, string cateName, string description)
        {
            this.CateID = cateID;
            this.CateName = cateName;
            this.Description = description;
        }
    }
}
