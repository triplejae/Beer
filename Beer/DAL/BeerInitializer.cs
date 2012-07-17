 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Beer.Models;
using System.Xml;
using System.Xml.XPath;

namespace Beer.DAL
{
    public class BeerInitializer : DropCreateDatabaseIfModelChanges<BeerContext>
    {
        protected override void Seed(BeerContext context)
        {
            //GenerateBreweries(context);     
            //GenerateBeers(context);
            GenerateStyleguideClasses(context);
            context.SaveChanges();
        }

        public void GenerateStyleguideClasses(BeerContext context)
        {         
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:/styleguide.xml");
            
            //Create StyleguideClass
            var classNodes = doc.DocumentElement.SelectNodes("class");
            int i = 1;
            int j = 1;
            foreach(XmlNode classItem in classNodes) 
            {            
              var x = new StyleguideClass();
              x.StyleguideClassName = classItem.Attributes["type"].Value;
              x.StyleguideClassNumber = i;
              //x.StyleguideClassID = i;
              context.StyleguideClasses.Add(x);
              context.SaveChanges();
              //Create Categories
              var categoryNodes = classItem.SelectNodes("category");
              
              foreach (XmlNode categoryItem in categoryNodes)
              {             
                var categoryName = categoryItem.SelectSingleNode("name").InnerText;
                var categoryNumber = Convert.ToInt16(categoryItem.Attributes["id"].Value);
                if (x.Categories == null)
                {
                    x.Categories = new List<Category>();
                }
                x.Categories.Add(new Category { 
                    CategoryNumber = categoryNumber, 
                    CategoryName = categoryName 
                });

                //Create SubCategories
                var subCategoryNodes = categoryItem.SelectNodes("subcategory");
                int k = 1;
                foreach (XmlNode subCategoryItem in subCategoryNodes)
                {
                  context.SubCategorys.Add(new SubCategory { 
                    SubCategoryNumber = subCategoryItem.Attributes["id"].Value, 
                    SubCategoryName = subCategoryItem.SelectSingleNode("name").InnerText, 
                    CategoryID = j,
                    Aroma = XmlNodeCheck(subCategoryItem.SelectSingleNode("aroma")),
                    Appearance = XmlNodeCheck(subCategoryItem.SelectSingleNode("appearance")),
                    Flavour = XmlNodeCheck(subCategoryItem.SelectSingleNode("flavor")),
                    Mouthfeel = XmlNodeCheck(subCategoryItem.SelectSingleNode("mouthfeel")),
                    Impression = XmlNodeCheck(subCategoryItem.SelectSingleNode("impression")),
                    History = XmlNodeCheck(subCategoryItem.SelectSingleNode("history")),
                    Comments = XmlNodeCheck(subCategoryItem.SelectSingleNode("comments")),
                    IBU = XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/ibu/low")) + " - " + XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/ibu/high")),
                    SRM = XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/srm/low")) + " - " + XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/srm/high")),
                    Ingredients = XmlNodeCheck(subCategoryItem.SelectSingleNode("ingredients")),
                    Examples = XmlNodeCheck(subCategoryItem.SelectSingleNode("examples")),
                    OG = XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/og/low")) + " - " + XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/og/high")),
                    FG = XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/fg/low")) + " - " + XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/fg/high")),
                    ABV = XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/abv/low")) + " - " + XmlNodeCheck(subCategoryItem.SelectSingleNode("stats/abv/high"))
                  });
                  k++;
                }
                
                j++;
              }
              i++;
            }
        }

        public void GenerateBreweries(BeerContext context)
        { 
            new List<Brewery>
            {
                new Brewery{ BreweryName = "Geoff's Brewery"},
                new Brewery{ BreweryName = "Mark's Brewery"},
                new Brewery{ BreweryName = "Matt's Brewery"},
                new Brewery{ BreweryName = "Simon's Brewery"}
            
            }.ForEach(b => context.Breweries.Add(b));


        }

        public void GenerateBeers(BeerContext context)
        {
            new List<BeerItem>
            {
                new BeerItem{ BeerItemName = "Hoppiness is an IPA", BreweryID = 1, SubCategoryID = 49},
                new BeerItem{ BeerItemName = "Brown Ale", BreweryID = 2, SubCategoryID = 38},
                new BeerItem{ BeerItemName = "Matt's American Pale Ale", BreweryID = 3, SubCategoryID = 33},
                new BeerItem{ BeerItemName = "Amber Ale", BreweryID = 4, SubCategoryID = 34},
            
            }.ForEach(b => context.Beers.Add(b));

        }

        /// <summary>
        /// Pass in an XML node and this function will return the node's InnerText value or and empty string 
        ///
        /// </summary>
        /// <param>test</param>
        /// <returns>test</returns>
        public string XmlNodeCheck(XmlNode node)
        {
            var nodeValue = "";
            if (node != null)
            {
                nodeValue = node.InnerText;
            }
            return nodeValue;
        }
    }

}