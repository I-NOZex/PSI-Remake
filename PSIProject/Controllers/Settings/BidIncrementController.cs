using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSIProject.DAL;
using PSIProject.Models.Settings;
using PSIProject.Helpers;

namespace PSIProject.Controllers.Settings
{
    public class BidIncrementController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: BidIncrement
        public ActionResult Index()
        {
            return View(db.BidInc.ToList());
        }

        // GET: BidIncrement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidIncrement bidIncrement = db.BidInc.Find(id);
            if (bidIncrement == null)
            {
                return HttpNotFound();
            }
            return View(bidIncrement);
        }

        // GET: BidIncrement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BidIncrement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Min,Max,Increment")] BidIncrement bidIncrement)
        {
            if (ModelState.IsValid)
            {
                db.BidInc.Add(bidIncrement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bidIncrement);
        }

        // GET: BidIncrement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidIncrement bidIncrement = db.BidInc.Find(id);
            if (bidIncrement == null)
            {
                return HttpNotFound();
            }
            return View(bidIncrement);
        }

        // POST: BidIncrement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Min,Max,Increment")] BidIncrement bidIncrement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bidIncrement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bidIncrement);
        }

        // GET: BidIncrement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidIncrement bidIncrement = db.BidInc.Find(id);
            if (bidIncrement == null)
            {
                return HttpNotFound();
            }
            return View(bidIncrement);
        }

        // POST: BidIncrement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BidIncrement bidIncrement = db.BidInc.Find(id);
            db.BidInc.Remove(bidIncrement);
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

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}
