using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSIProject.DAL;
using PSIProject.Models.Users;
using PSIProject.Controllers;
using PSIProject.Helpers;

namespace PSIProject.Controllers.Users
{
    public class RateHistoryController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: RateHistory
        public ActionResult Index()
        {
            var rateHistory = db.RateHistory.Include(r => r.User);
            return View(rateHistory.ToList());
        }

        // GET: RateHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateHistory rateHistory = db.RateHistory.Find(id);
            if (rateHistory == null)
            {
                return HttpNotFound();
            }
            return View(rateHistory);
        }

        // GET: RateHistory/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: RateHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Date,PointsSeller,PointsBuyer,Description")] RateHistory rateHistory)
        {
            if (ModelState.IsValid)
            {
                db.RateHistory.Add(rateHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", rateHistory.UserID);
            return View(rateHistory);
        }

        // GET: RateHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateHistory rateHistory = db.RateHistory.Find(id);
            if (rateHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", rateHistory.UserID);
            return View(rateHistory);
        }

        // POST: RateHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Date,PointsSeller,PointsBuyer,Description")] RateHistory rateHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", rateHistory.UserID);
            return View(rateHistory);
        }

        // GET: RateHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateHistory rateHistory = db.RateHistory.Find(id);
            if (rateHistory == null)
            {
                return HttpNotFound();
            }
            return View(rateHistory);
        }

        // POST: RateHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateHistory rateHistory = db.RateHistory.Find(id);
            db.RateHistory.Remove(rateHistory);
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
