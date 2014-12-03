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
    public class PostalCodeController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: PostalCode
        public ActionResult Index()
        {
            var postalCode = db.PostalCode.Include(p => p.Locality);
            return View(postalCode.ToList());
        }

        // GET: PostalCode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostalCode postalCode = db.PostalCode.Find(id);
            if (postalCode == null)
            {
                return HttpNotFound();
            }
            return View(postalCode);
        }

        // GET: PostalCode/Create
        public ActionResult Create()
        {
            ViewBag.LocalityID = new SelectList(db.Locality, "ID", "Name");
            return View();
        }

        // POST: PostalCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ZipCode,LocalityID")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                db.PostalCode.Add(postalCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalityID = new SelectList(db.Locality, "ID", "Name", postalCode.LocalityID);
            return View(postalCode);
        }

        // GET: PostalCode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostalCode postalCode = db.PostalCode.Find(id);
            if (postalCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalityID = new SelectList(db.Locality, "ID", "Name", postalCode.LocalityID);
            return View(postalCode);
        }

        // POST: PostalCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ZipCode,LocalityID")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postalCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalityID = new SelectList(db.Locality, "ID", "Name", postalCode.LocalityID);
            return View(postalCode);
        }

        // GET: PostalCode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostalCode postalCode = db.PostalCode.Find(id);
            if (postalCode == null)
            {
                return HttpNotFound();
            }
            return View(postalCode);
        }

        // POST: PostalCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostalCode postalCode = db.PostalCode.Find(id);
            db.PostalCode.Remove(postalCode);
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
