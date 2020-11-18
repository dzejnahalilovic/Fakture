using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fakture_;

namespace Fakture_.Controllers
{
    public class Popust1Controller : Controller
    {
        private faktureDBEntities db = new faktureDBEntities();

        // GET: Popust1
        public ActionResult Index()
        {
            return View(db.Popust1.ToList());
        }

        // GET: Popust1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Popust1 popust1 = db.Popust1.Find(id);
            if (popust1 == null)
            {
                return HttpNotFound();
            }
            return View(popust1);
        }

        // GET: Popust1/Create
        public ActionResult Create()
        {
            faktureDBEntities db = new faktureDBEntities();
            var data = db.Popust1;
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "25%", Value = "25" });
            li.Add(new SelectListItem() { Text = "17%", Value = "17" });
            ViewBag.abc = new SelectList(li, "Value", "Text");
            return View();
        }

        // POST: Popust1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Popust")] Popust1 popust1)
        {
            if (ModelState.IsValid)
            {
                db.Popust1.Add(popust1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(popust1);
        }

        // GET: Popust1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Popust1 popust1 = db.Popust1.Find(id);
            if (popust1 == null)
            {
                return HttpNotFound();
            }
            return View(popust1);
        }

        // POST: Popust1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Popust")] Popust1 popust1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(popust1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(popust1);
        }

        // GET: Popust1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Popust1 popust1 = db.Popust1.Find(id);
            if (popust1 == null)
            {
                return HttpNotFound();
            }
            return View(popust1);
        }

        // POST: Popust1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Popust1 popust1 = db.Popust1.Find(id);
            db.Popust1.Remove(popust1);
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
