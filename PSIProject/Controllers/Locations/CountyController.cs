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
    public class CountyController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: County
        public ActionResult Index()
        {
            var county = db.County.Include(c => c.District);
            return View(county.ToList());
        }

        // GET: County/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.County.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // GET: County/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.District, "ID", "Name");
            return View();
        }

        // POST: County/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DistrictID")] County county)
        {
            if (ModelState.IsValid)
            {
                db.County.Add(county);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.District, "ID", "Name", county.DistrictID);
            return View(county);
        }

        // GET: County/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.County.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.District, "ID", "Name", county.DistrictID);
            return View(county);
        }

        // POST: County/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DistrictID")] County county)
        {
            if (ModelState.IsValid)
            {
                db.Entry(county).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.District, "ID", "Name", county.DistrictID);
            return View(county);
        }

        // GET: County/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.County.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // POST: County/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            County county = db.County.Find(id);
            db.County.Remove(county);
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
