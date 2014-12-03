using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSIProject.DAL;
using PSIProject.Models.Auctions;

using PSIProject.Controllers;
using PSIProject.Helpers;

namespace PSIProject.Controllers.Auctions
{
    public class ReportedAuctionController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: ReportedAuction
        public ActionResult Index()
        {
            var reportedAuctions = db.ReportedAuction.Include(r => r.Auction).Include(r => r.User);
            return View(reportedAuctions.ToList());
        }

        // GET: ReportedAuction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportedAuction reportedAuction = db.ReportedAuction.Find(id);
            if (reportedAuction == null)
            {
                return HttpNotFound();
            }
            return View(reportedAuction);
        }

        // GET: ReportedAuction/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title");
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: ReportedAuction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuctionID,UserID,Date,Motive")] ReportedAuction reportedAuction)
        {
            if (ModelState.IsValid)
            {
                db.ReportedAuction.Add(reportedAuction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", reportedAuction.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", reportedAuction.UserID);
            return View(reportedAuction);
        }

        // GET: ReportedAuction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportedAuction reportedAuction = db.ReportedAuction.Find(id);
            if (reportedAuction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", reportedAuction.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", reportedAuction.UserID);
            return View(reportedAuction);
        }

        // POST: ReportedAuction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuctionID,UserID,Date,Motive")] ReportedAuction reportedAuction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportedAuction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", reportedAuction.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", reportedAuction.UserID);
            return View(reportedAuction);
        }

        // GET: ReportedAuction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportedAuction reportedAuction = db.ReportedAuction.Find(id);
            if (reportedAuction == null)
            {
                return HttpNotFound();
            }
            return View(reportedAuction);
        }

        // POST: ReportedAuction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportedAuction reportedAuction = db.ReportedAuction.Find(id);
            db.ReportedAuction.Remove(reportedAuction);
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
