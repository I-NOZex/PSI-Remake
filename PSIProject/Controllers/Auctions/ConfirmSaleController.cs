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
    public class ConfirmSaleController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: ConfirmSale
        public ActionResult Index()
        {
            var confirmSale = db.ConfirmSale.Include(c => c.Buyer).Include(c => c.Seller);
            return View(confirmSale.ToList());
        }

        // GET: ConfirmSale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmSale confirmSale = db.ConfirmSale.Find(id);
            if (confirmSale == null)
            {
                return HttpNotFound();
            }
            return View(confirmSale);
        }

        // GET: ConfirmSale/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name");
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: ConfirmSale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ConfirmationCode,BuyerID,BuyerConfirmed,BuyerDateConfirmation,SellerID,SellerConfirmed,SellerDateConfirmation")] ConfirmSale confirmSale)
        {
            if (ModelState.IsValid)
            {
                db.ConfirmSale.Add(confirmSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.BuyerID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.SellerID);
            return View(confirmSale);
        }

        // GET: ConfirmSale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmSale confirmSale = db.ConfirmSale.Find(id);
            if (confirmSale == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.BuyerID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.SellerID);
            return View(confirmSale);
        }

        // POST: ConfirmSale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ConfirmationCode,BuyerID,BuyerConfirmed,BuyerDateConfirmation,SellerID,SellerConfirmed,SellerDateConfirmation")] ConfirmSale confirmSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(confirmSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.BuyerID);
            ViewBag.SellerID = new SelectList(db.ApplicationUser, "Id", "Name", confirmSale.SellerID);
            return View(confirmSale);
        }

        // GET: ConfirmSale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmSale confirmSale = db.ConfirmSale.Find(id);
            if (confirmSale == null)
            {
                return HttpNotFound();
            }
            return View(confirmSale);
        }

        // POST: ConfirmSale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfirmSale confirmSale = db.ConfirmSale.Find(id);
            db.ConfirmSale.Remove(confirmSale);
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
