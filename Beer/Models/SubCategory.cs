using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Beer.Models
{
    public class SubCategory
    {
        [Display(Name="Subcategory Number")]
        public int SubCategoryID { get; set; }
        [Display(Name = "Category Number")]
        public int CategoryID { get; set; }
        [Display(Name = "Style Number")]
        public string SubCategoryNumber { get; set; }
        [Display(Name = "Name")]
        public string SubCategoryName { get; set; }
        public string Aroma { get; set; }
        public string Appearance { get; set; }
        public string Flavour { get; set; }
        public string Mouthfeel { get; set; }
        public string Impression { get; set; }
        public string Ingredients { get; set; }
        public string History { get; set; }
        public string Comments { get; set; }
        public string OG  { get; set; }
        public string FG { get; set; }
        public string IBU { get; set; }
        public string SRM { get; set; }
        public string ABV { get; set; }
        public string Examples { get; set; }
        public virtual List<BeerItem> BeerItems { get; set; }
    }
}