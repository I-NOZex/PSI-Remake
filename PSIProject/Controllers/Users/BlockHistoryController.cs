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
    public class BlockHistoryController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: BlockHistory
        public ActionResult Index()
        {
            var blockHistory = db.BlockHistory.Include(b => b.User);
            return View(blockHistory.ToList());
        }

        // GET: BlockHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockHistory blockHistory = db.BlockHistory.Find(id);
            if (blockHistory == null)
            {
                return HttpNotFound();
            }
            return View(blockHistory);
        }

        // GET: BlockHistory/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: BlockHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Date,IsBlocked,Reason,Duration")] BlockHistory blockHistory)
        {
            if (ModelState.IsValid)
            {
                db.BlockHistory.Add(blockHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", blockHistory.UserID);
            return View(blockHistory);
        }

        // GET: BlockHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockHistory blockHistory = db.BlockHistory.Find(id);
            if (blockHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", blockHistory.UserID);
            return View(blockHistory);
        }

        // POST: BlockHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Date,IsBlocked,Reason,Duration")] BlockHistory blockHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blockHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", blockHistory.UserID);
            return View(blockHistory);
        }

        // GET: BlockHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockHistory blockHistory = db.BlockHistory.Find(id);
            if (blockHistory == null)
            {
                return HttpNotFound();
            }
            return View(blockHistory);
        }

        // POST: BlockHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlockHistory blockHistory = db.BlockHistory.Find(id);
            db.BlockHistory.Remove(blockHistory);
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
