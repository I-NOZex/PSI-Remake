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
    public class SaleController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Sale
        public ActionResult Index()
        {
            var sale = db.Sale.Include(s => s.Auction).Include(s => s.Buyer).Include(s => s.ConfirmSale).Include(s => s.Seller);
            return View(sale.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title");
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name");
            ViewBag.ConfirmSaleID = new SelectList(db.ConfirmSale, "ID", "ConfirmationCode");
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuctionID,SellerID,BuyerID,ConfirmSaleID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sale.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", sale.AuctionID);
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.BuyerID);
            ViewBag.ConfirmSaleID = new SelectList(db.ConfirmSale, "ID", "ConfirmationCode", sale.ConfirmSaleID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.SellerID);
            return View(sale);
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", sale.AuctionID);
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.BuyerID);
            ViewBag.ConfirmSaleID = new SelectList(db.ConfirmSale, "ID", "ConfirmationCode", sale.ConfirmSaleID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.SellerID);
            return View(sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuctionID,SellerID,BuyerID,ConfirmSaleID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", sale.AuctionID);
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.BuyerID);
            ViewBag.ConfirmSaleID = new SelectList(db.ConfirmSale, "ID", "ConfirmationCode", sale.ConfirmSaleID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", sale.SellerID);
            return View(sale);
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sale.Find(id);
            db.Sale.Remove(sale);
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
