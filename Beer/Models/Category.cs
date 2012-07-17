using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beer.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int StyleguideClassID { get; set; }
        public int CategoryNumber { get; set; }
        public string CategoryName { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
        
    }
}