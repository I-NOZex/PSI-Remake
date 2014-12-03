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
    public class TextController : BaseController
    {
        private AuctionsContext db = new AuctionsContext();

        // GET: Text
        public ActionResult Index()
        {
            return View(db.Text.ToList());
        }

        // GET: Text/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Text.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // GET: Text/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Text/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,TextType")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Text.Add(text);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(text);
        }

        // GET: Text/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Text.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Text/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,TextType")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Entry(text).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(text);
        }

        // GET: Text/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Text.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Text text = db.Text.Find(id);
            db.Text.Remove(text);
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
