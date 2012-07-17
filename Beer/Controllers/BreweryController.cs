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
    public class BreweryController : Controller
    {
        private BeerContext db = new BeerContext();

        //
        // GET: /Brewery/

        public ViewResult Index()
        {
            return View(db.Breweries.ToList());
        }

        //
        // GET: /Brewery/Details/5

        public ViewResult Details(int id)
        {
            Brewery brewery = db.Breweries.Find(id);
            return View(brewery);
        }

        //
        // GET: /Brewery/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Brewery/Create

        [HttpPost]
        public ActionResult Create(Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                db.Breweries.Add(brewery);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(brewery);
        }
        
        //
        // GET: /Brewery/Edit/5
 
        public ActionResult Edit(int id)
        {
            Brewery brewery = db.Breweries.Find(id);
            return View(brewery);
        }

        //
        // POST: /Brewery/Edit/5

        [HttpPost]
        public ActionResult Edit(Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brewery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brewery);
        }

        //
        // GET: /Brewery/Delete/5
 
        public ActionResult Delete(int id)
        {
            Brewery brewery = db.Breweries.Find(id);
            return View(brewery);
        }

        //
        // POST: /Brewery/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Brewery brewery = db.Breweries.Find(id);
            db.Breweries.Remove(brewery);
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