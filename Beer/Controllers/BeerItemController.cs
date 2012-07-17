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
    public class BeerItemController : Controller
    {
        private BeerContext db = new BeerContext();

        //
        // GET: /BeerItem/

        public ViewResult Index()
        {
            return View(db.Beers.ToList());
        }

        //
        // GET: /BeerItem/Details/5

        public ViewResult Details(int id)
        {
            BeerItem beeritem = db.Beers.Find(id);
            return View(beeritem);
        }

        //
        // GET: /BeerItem/Create

        public ActionResult Create()
        {
            var list = from item in db.SubCategorys select new {item.SubCategoryID, item.SubCategoryName};
            ViewBag.SubCategoryID = new SelectList(list, "SubCategoryID", "SubCategoryName");
            return View();
        } 

        //
        // POST: /BeerItem/Create

        [HttpPost]
        public ActionResult Create(BeerItem beeritem)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beeritem);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(beeritem);
        }
        
        //
        // GET: /BeerItem/Edit/5
 
        public ActionResult Edit(int id)
        {
            BeerItem beeritem = db.Beers.Find(id);
            return View(beeritem);
        }

        //
        // POST: /BeerItem/Edit/5

        [HttpPost]
        public ActionResult Edit(BeerItem beeritem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beeritem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beeritem);
        }

        //
        // GET: /BeerItem/Delete/5
 
        public ActionResult Delete(int id)
        {
            BeerItem beeritem = db.Beers.Find(id);
            return View(beeritem);
        }

        //
        // POST: /BeerItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BeerItem beeritem = db.Beers.Find(id);
            db.Beers.Remove(beeritem);
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