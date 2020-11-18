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
    public class DetaljiFakture1Controller : Controller
    {
        private faktureDBEntities db = new faktureDBEntities();

        // GET: DetaljiFakture1
        public ActionResult Index()
        {
            var detaljiFakture1 = db.DetaljiFakture1.Include(d => d.Faktura1).Include(d => d.Popust1).Include(d => d.Proizvod1);
            return View(detaljiFakture1.ToList());
        }

        // GET: DetaljiFakture1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetaljiFakture1 detaljiFakture1 = db.DetaljiFakture1.Find(id);
            if (detaljiFakture1 == null)
            {
                return HttpNotFound();
            }
            return View(detaljiFakture1);
        }

        // GET: DetaljiFakture1/Create
        public ActionResult Create()
        {
            ViewBag.Faktura = new SelectList(db.Faktura1, "Id", "BrojFakture");
            ViewBag.Popust = new SelectList(db.Popust1, "Id", "Popust");
            ViewBag.Proizvod = new SelectList(db.Proizvods, "Id", "Naziv");
            return View();
        }

        // POST: DetaljiFakture1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Faktura,Proizvod,Cijena,Kolicina,Popust,Ukupno")] DetaljiFakture1 detaljiFakture1)
        {
            if (ModelState.IsValid)
            {
                db.DetaljiFakture1.Add(detaljiFakture1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faktura = new SelectList(db.Faktura1, "Id", "BrojFakture", detaljiFakture1.Faktura);
            ViewBag.Popust = new SelectList(db.Popust1, "Id", "Popust", detaljiFakture1.Popust);
            ViewBag.Proizvod = new SelectList(db.Proizvods, "Id", "Naziv", detaljiFakture1.Proizvod);
            return View(detaljiFakture1);
        }

        // GET: DetaljiFakture1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetaljiFakture1 detaljiFakture1 = db.DetaljiFakture1.Find(id);
            if (detaljiFakture1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faktura = new SelectList(db.Faktura1, "Id", "Id", detaljiFakture1.Faktura);
            ViewBag.Popust = new SelectList(db.Popust1, "Id", "Id", detaljiFakture1.Popust);
            ViewBag.Proizvod = new SelectList(db.Proizvods, "Id", "Naziv", detaljiFakture1.Proizvod);
            return View(detaljiFakture1);
        }

        // POST: DetaljiFakture1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Faktura,Proizvod,Cijena,Kolicina,Popust,Ukupno")] DetaljiFakture1 detaljiFakture1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detaljiFakture1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Faktura = new SelectList(db.Faktura1, "Id", "Id", detaljiFakture1.Faktura);
            ViewBag.Popust = new SelectList(db.Popust1, "Id", "Id", detaljiFakture1.Popust);
            ViewBag.Proizvod = new SelectList(db.Proizvods, "Id", "Naziv", detaljiFakture1.Proizvod);
            return View(detaljiFakture1);
        }

        // GET: DetaljiFakture1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetaljiFakture1 detaljiFakture1 = db.DetaljiFakture1.Find(id);
            if (detaljiFakture1 == null)
            {
                return HttpNotFound();
            }
            return View(detaljiFakture1);
        }

        // POST: DetaljiFakture1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetaljiFakture1 detaljiFakture1 = db.DetaljiFakture1.Find(id);
            db.DetaljiFakture1.Remove(detaljiFakture1);
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
