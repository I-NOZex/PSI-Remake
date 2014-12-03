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
    public class FriendController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Friend
        public ActionResult Index()
        {
            var friend = db.Friend.Include(f => f.User).Include(f => f.UserFriend);
            return View(friend.ToList());
        }

        // GET: Friend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name");
            ViewBag.FriendID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Friend/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,FriendID,Status")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friend.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", friend.UserID);
            ViewBag.FriendID = new SelectList(db.ApplicationUser, "Id", "Name", friend.FriendID);
            return View(friend);
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", friend.UserID);
            ViewBag.FriendID = new SelectList(db.ApplicationUser, "Id", "Name", friend.FriendID);
            return View(friend);
        }

        // POST: Friend/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,FriendID,Status")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.ApplicationUser, "Id", "Name", friend.UserID);
            ViewBag.FriendID = new SelectList(db.ApplicationUser, "Id", "Name", friend.FriendID);
            return View(friend);
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friend.Find(id);
            db.Friend.Remove(friend);
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
