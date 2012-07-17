using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Beer.Models
{
    public class BeerItem
    {
        public int BeerItemID { get; set; }
        public int SubCategoryID { get; set; }
        public int BreweryID { get; set; }
        public string BeerItemName { get; set; }
        public string BeerItemComments { get; set; } 
    }
}