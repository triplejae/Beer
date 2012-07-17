using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beer.Models
{
    public class Brewery
    {
        public int BreweryID { get; set; }
        public string BreweryName { get; set; }
        public string Equiptment { get; set; }
        public Boolean AllGrain { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}