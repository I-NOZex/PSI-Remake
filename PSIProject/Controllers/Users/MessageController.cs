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
    public class MessageController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Message
        public ActionResult Index()
        {
            var message = db.Message.Include(m => m.MessageOrigin).Include(m => m.Receiver).Include(m => m.Sender);
            return View(message.ToList());
        }

        // GET: Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            ViewBag.MessageOriginID = new SelectList(db.Message, "ID", "SenderID");
            ViewBag.ReceiverID = new SelectList(db.ApplicationUser, "Id", "Name");
            ViewBag.SenderID = new SelectList(db.ApplicationUser, "Id", "Name");
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SenderID,ReceiverID,Date,TextMessage,MessageOriginID,MessageRead")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MessageOriginID = new SelectList(db.Message, "ID", "SenderID", message.MessageOriginID);
            ViewBag.ReceiverID = new SelectList(db.ApplicationUser, "Id", "Name", message.ReceiverID);
            ViewBag.SenderID = new SelectList(db.ApplicationUser, "Id", "Name", message.SenderID);
            return View(message);
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.MessageOriginID = new SelectList(db.Message, "ID", "SenderID", message.MessageOriginID);
            ViewBag.ReceiverID = new SelectList(db.ApplicationUser, "Id", "Name", message.ReceiverID);
            ViewBag.SenderID = new SelectList(db.ApplicationUser, "Id", "Name", message.SenderID);
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SenderID,ReceiverID,Date,TextMessage,MessageOriginID,MessageRead")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MessageOriginID = new SelectList(db.Message, "ID", "SenderID", message.MessageOriginID);
            ViewBag.ReceiverID = new SelectList(db.ApplicationUser, "Id", "Name", message.ReceiverID);
            ViewBag.SenderID = new SelectList(db.ApplicationUser, "Id", "Name", message.SenderID);
            return View(message);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Message.Find(id);
            db.Message.Remove(message);
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
