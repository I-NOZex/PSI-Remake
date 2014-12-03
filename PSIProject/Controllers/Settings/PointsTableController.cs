using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSIProject.DAL;
using PSIProject.Models.Settings;
using PSIProject.Helpers;
using System.Web;
using System;

namespace PSIProject.Controllers.Settings
{
    public class PointsTableController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: PointsTable
        public ActionResult Index()
        {
            return View(db.PointsTable.ToList());
        }

        // GET: PointsTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsTable pointsTable = db.PointsTable.Find(id);
            if (pointsTable == null)
            {
                return HttpNotFound();
            }
            return View(pointsTable);
        }

        // GET: PointsTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PointsTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Points,Description")] PointsTable pointsTable)
        {
            if (ModelState.IsValid)
            {
                db.PointsTable.Add(pointsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointsTable);
        }

        // GET: PointsTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsTable pointsTable = db.PointsTable.Find(id);
            if (pointsTable == null)
            {
                return HttpNotFound();
            }
            return View(pointsTable);
        }

        // POST: PointsTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Points,Description")] PointsTable pointsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointsTable);
        }

        // GET: PointsTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsTable pointsTable = db.PointsTable.Find(id);
            if (pointsTable == null)
            {
                return HttpNotFound();
            }
            return View(pointsTable);
        }

        // POST: PointsTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PointsTable pointsTable = db.PointsTable.Find(id);
            db.PointsTable.Remove(pointsTable);
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
