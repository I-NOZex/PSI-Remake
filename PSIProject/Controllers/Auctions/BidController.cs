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
    public class BidController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Bid
        public ActionResult Index()
        {
            var bid = db.Bid.Include(b => b.Auction).Include(b => b.User);
            return View(bid.ToList());
        }

        // GET: Bid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: Bid/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title");
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Bid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuctionID,UserID,BidValueInc")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bid.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", bid.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", bid.UserID);
            return View(bid);
        }

        // GET: Bid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", bid.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", bid.UserID);
            return View(bid);
        }

        // POST: Bid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuctionID,UserID,BidValueInc")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", bid.AuctionID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", bid.UserID);
            return View(bid);
        }

        // GET: Bid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bid bid = db.Bid.Find(id);
            db.Bid.Remove(bid);
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
