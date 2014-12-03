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
    public class FeedbackEvaluationController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: FeedbackEvaluation
        public ActionResult Index()
        {
            var feedbackEvaluation = db.FeedbackEvaluation.Include(f => f.Feedback).Include(f => f.FeedbackItem);
            return View(feedbackEvaluation.ToList());
        }

        // GET: FeedbackEvaluation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackEvaluation feedbackEvaluation = db.FeedbackEvaluation.Find(id);
            if (feedbackEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(feedbackEvaluation);
        }

        // GET: FeedbackEvaluation/Create
        public ActionResult Create()
        {
            ViewBag.FeedbackID = new SelectList(db.Feedback, "ID", "ClassifierID");
            ViewBag.FeedbackItemID = new SelectList(db.FeedbackItem, "ID", "Description");
            return View();
        }

        // POST: FeedbackEvaluation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FeedbackID,FeedbackItemID,Evaluation")] FeedbackEvaluation feedbackEvaluation)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackEvaluation.Add(feedbackEvaluation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FeedbackID = new SelectList(db.Feedback, "ID", "ClassifierID", feedbackEvaluation.FeedbackID);
            ViewBag.FeedbackItemID = new SelectList(db.FeedbackItem, "ID", "Description", feedbackEvaluation.FeedbackItemID);
            return View(feedbackEvaluation);
        }

        // GET: FeedbackEvaluation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackEvaluation feedbackEvaluation = db.FeedbackEvaluation.Find(id);
            if (feedbackEvaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeedbackID = new SelectList(db.Feedback, "ID", "ClassifierID", feedbackEvaluation.FeedbackID);
            ViewBag.FeedbackItemID = new SelectList(db.FeedbackItem, "ID", "Description", feedbackEvaluation.FeedbackItemID);
            return View(feedbackEvaluation);
        }

        // POST: FeedbackEvaluation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FeedbackID,FeedbackItemID,Evaluation")] FeedbackEvaluation feedbackEvaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackEvaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeedbackID = new SelectList(db.Feedback, "ID", "ClassifierID", feedbackEvaluation.FeedbackID);
            ViewBag.FeedbackItemID = new SelectList(db.FeedbackItem, "ID", "Description", feedbackEvaluation.FeedbackItemID);
            return View(feedbackEvaluation);
        }

        // GET: FeedbackEvaluation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackEvaluation feedbackEvaluation = db.FeedbackEvaluation.Find(id);
            if (feedbackEvaluation == null)
            {
                return HttpNotFound();
            }
            return View(feedbackEvaluation);
        }

        // POST: FeedbackEvaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackEvaluation feedbackEvaluation = db.FeedbackEvaluation.Find(id);
            db.FeedbackEvaluation.Remove(feedbackEvaluation);
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
