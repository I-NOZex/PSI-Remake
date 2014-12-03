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
    public class PictureController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Picture
        public ActionResult Index()
        {
            var picture = db.Picture.Include(p => p.Auction);
            return View(picture.ToList());
        }

        // GET: Picture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Picture.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title");
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Path,AuctionID,Order")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Picture.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", picture.AuctionID);
            return View(picture);
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Picture.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", picture.AuctionID);
            return View(picture);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Path,AuctionID,Order")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionID = new SelectList(db.Auction, "ID", "Title", picture.AuctionID);
            return View(picture);
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Picture.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Picture.Find(id);
            db.Picture.Remove(picture);
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
