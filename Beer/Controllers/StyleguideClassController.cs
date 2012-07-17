using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beer.Models;

namespace Beer.Controllers
{ 
    public class StyleguideClassController : Controller
    {
        private BeerContext db = new BeerContext();

        //
        // GET: /StyleguideClass/

        public ViewResult Index()
        {
            ViewBag.Heading = "Beer, Mead and Cider style definitions";
            ViewBag.intro = "Here is a listing of beer, mead and cider styles as defined in the BJCP.";
            var styleguideClassModel = db.StyleguideClasses.Include("Categories");
            return View(styleguideClassModel);
            
        }

        //
        // GET: /StyleguideClass/Details/5

        public ViewResult Details(int id)
        {
            ViewBag.Heading = "Category";
            var categoryModel = db.Categories.Find(id);
            return View(categoryModel);
        }

        //
        // GET: /StyleguideClass/SubCategory/5

        public ViewResult SubCategory(int id)
        {
            ViewBag.Heading = "BJCP Sub-Cate gories";
            SubCategory subcategory = db.SubCategorys.Find(id);
            return View(subcategory);
        }

        public ActionResult BeerItem(int id)
        {
            ViewBag.Heading = "Related Beers";
            var beerItems = db.SubCategorys.Include("BeerItems");
            return PartialView(beerItems);
            
        }
        

        //
        // GET: /StyleguideClass/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /StyleguideClass/Create

        [HttpPost]
        public ActionResult Create(StyleguideClass styleguideclass)
        {
            if (ModelState.IsValid)
            {
                db.StyleguideClasses.Add(styleguideclass);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(styleguideclass);
        }
        
        //
        // GET: /StyleguideClass/Edit/5
 
        public ActionResult Edit(int id)
        {
            StyleguideClass styleguideclass = db.StyleguideClasses.Find(id);
            return View(styleguideclass);
        }

        //
        // POST: /StyleguideClass/Edit/5

        [HttpPost]
        public ActionResult Edit(StyleguideClass styleguideclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(styleguideclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(styleguideclass);
        }

        //
        // GET: /StyleguideClass/Delete/5
 
        public ActionResult Delete(int id)
        {
            StyleguideClass styleguideclass = db.StyleguideClasses.Find(id);
            return View(styleguideclass);
        }

        //
        // POST: /StyleguideClass/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            StyleguideClass styleguideclass = db.StyleguideClasses.Find(id);
            db.StyleguideClasses.Remove(styleguideclass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}