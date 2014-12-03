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
    public class FeedbackController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Feedback
        public ActionResult Index()
        {
            var feedback = db.Feedback.Include(f => f.Auction).Include(f => f.Classified).Include(f => f.Classifier);
            return View(feedback.ToList());
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title");
            ViewBag.ClassifiedID = new SelectList(db.ApplicationUser, "Id", "Name");
            ViewBag.ClassifierID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuctionID,ClassifierID,AuctionUserType,ClassifiedID,Description")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedback.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", feedback.AuctionID);
            ViewBag.ClassifiedID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifiedID);
            ViewBag.ClassifierID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifierID);
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", feedback.AuctionID);
            ViewBag.ClassifiedID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifiedID);
            ViewBag.ClassifierID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifierID);
            return View(feedback);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuctionID,ClassifierID,AuctionUserType,ClassifiedID,Description")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", feedback.AuctionID);
            ViewBag.ClassifiedID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifiedID);
            ViewBag.ClassifierID = new SelectList(db.ApplicationUser, "Id", "Name", feedback.ClassifierID);
            return View(feedback);
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedback.Find(id);
            db.Feedback.Remove(feedback);
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
