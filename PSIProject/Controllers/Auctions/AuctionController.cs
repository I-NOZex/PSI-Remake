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
    public class AuctionController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Auction
        public ActionResult Index()
        {
            var auction = db.Auction.Include(a => a.Category).Include(a => a.PostalCode).Include(a => a.User);
            return View(auction.ToList());
        }

        // GET: Auction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auction.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "CategoryName");
            ViewBag.PostalCodeID = new SelectList(db.PostalCode, "ID", "ZipCode");
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,PostalCodeID,UserID,CategoryID,ArticleStatus,DeliveryCondition,DateTimeBegin,DateTimeEnd,StartingPrice,MinPrice,DirectSell,BuyNowPrice,ShipmentCondition,Extended,Status")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Auction.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category, "ID", "CategoryName", auction.CategoryID);
            ViewBag.PostalCodeID = new SelectList(db.PostalCode, "ID", "ZipCode", auction.PostalCodeID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", auction.UserID);
            return View(auction);
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auction.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "CategoryName", auction.CategoryID);
            ViewBag.PostalCodeID = new SelectList(db.PostalCode, "ID", "ZipCode", auction.PostalCodeID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", auction.UserID);
            return View(auction);
        }

        // POST: Auction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,PostalCodeID,UserID,CategoryID,ArticleStatus,DeliveryCondition,DateTimeBegin,DateTimeEnd,StartingPrice,MinPrice,DirectSell,BuyNowPrice,ShipmentCondition,Extended,Status")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "CategoryName", auction.CategoryID);
            ViewBag.PostalCodeID = new SelectList(db.PostalCode, "ID", "ZipCode", auction.PostalCodeID);
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", auction.UserID);
            return View(auction);
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = db.Auction.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auction auction = db.Auction.Find(id);
            db.Auction.Remove(auction);
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
