using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSIProject.DAL;
using PSIProject.Models.Locations;
using PSIProject.Controllers;
using PSIProject.Helpers;

namespace PSIProject.Controllers.Locations
{
    public class LocalityController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Locality
        public ActionResult Index()
        {
            var locality = db.Locality.Include(l => l.County);
            return View(locality.ToList());
        }

        // GET: Locality/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Locality.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }
            return View(locality);
        }

        // GET: Locality/Create
        public ActionResult Create()
        {
            ViewBag.CountyID = new SelectList(db.County, "ID", "Name");
            return View();
        }

        // POST: Locality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CountyID")] Locality locality)
        {
            if (ModelState.IsValid)
            {
                db.Locality.Add(locality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountyID = new SelectList(db.County, "ID", "Name", locality.CountyID);
            return View(locality);
        }

        // GET: Locality/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Locality.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountyID = new SelectList(db.County, "ID", "Name", locality.CountyID);
            return View(locality);
        }

        // POST: Locality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CountyID")] Locality locality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountyID = new SelectList(db.County, "ID", "Name", locality.CountyID);
            return View(locality);
        }

        // GET: Locality/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locality locality = db.Locality.Find(id);
            if (locality == null)
            {
                return HttpNotFound();
            }
            return View(locality);
        }

        // POST: Locality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locality locality = db.Locality.Find(id);
            db.Locality.Remove(locality);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
