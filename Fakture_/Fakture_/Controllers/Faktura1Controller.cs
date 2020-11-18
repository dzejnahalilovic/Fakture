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
    public class Faktura1Controller : Controller
    {
        private faktureDBEntities db = new faktureDBEntities();

        // GET: Faktura1
        public ActionResult Index()
        {
            var faktura1 = db.Faktura1.Include(f => f.Korisnik1);
            return View(faktura1.ToList());
        }

        // GET: Faktura1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktura1 faktura1 = db.Faktura1.Find(id);
            if (faktura1 == null)
            {
                return HttpNotFound();
            }
            return View(faktura1);
        }

        // GET: Faktura1/Create
        public ActionResult Create()
        {
            ViewBag.Korisnik = new SelectList(db.Korisniks, "Id", "Ime");
            return View();
        }

        // POST: Faktura1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BrojFakture,DatumKreiranja,DatumDospijeca,Korisnik")] Faktura1 faktura1)
        {
            if (ModelState.IsValid)
            {
                db.Faktura1.Add(faktura1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Korisnik = new SelectList(db.Korisniks, "Id", "Ime", faktura1.Korisnik);
            return View(faktura1);
        }

        // GET: Faktura1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktura1 faktura1 = db.Faktura1.Find(id);
            if (faktura1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Korisnik = new SelectList(db.Korisniks, "Id", "Ime", faktura1.Korisnik);
            return View(faktura1);
        }

        // POST: Faktura1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrojFakture,DatumKreiranja,DatumDospijeca,Korisnik")] Faktura1 faktura1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faktura1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Korisnik = new SelectList(db.Korisniks, "Id", "Ime", faktura1.Korisnik);
            return View(faktura1);
        }

        // GET: Faktura1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktura1 faktura1 = db.Faktura1.Find(id);
            if (faktura1 == null)
            {
                return HttpNotFound();
            }
            return View(faktura1);
        }

        // POST: Faktura1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faktura1 faktura1 = db.Faktura1.Find(id);
            db.Faktura1.Remove(faktura1);
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
