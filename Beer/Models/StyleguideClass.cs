using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beer.Models
{  
    public class StyleguideClass
    {
        public int StyleguideClassID { get; set; }
        public int StyleguideClassNumber { get; set; }
        public string StyleguideClassName { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}