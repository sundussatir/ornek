using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class KitapTurusController : Controller
    {
        private WebApplication5Context db = new WebApplication5Context();

        // GET: KitapTurus
        public ActionResult Index()
        {
            return View(db.KitapTurus.ToList());
        }

        // GET: KitapTurus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapTuru kitapTuru = db.KitapTurus.Find(id);
            if (kitapTuru == null)
            {
                return HttpNotFound();
            }
            return View(kitapTuru);
        }

        // GET: KitapTurus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitapTurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KitapTuruId,KitapTuruAdi,KitapTuruAciklamasi")] KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                db.KitapTurus.Add(kitapTuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitapTuru);
        }

        // GET: KitapTurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapTuru kitapTuru = db.KitapTurus.Find(id);
            if (kitapTuru == null)
            {
                return HttpNotFound();
            }
            return View(kitapTuru);
        }

        // POST: KitapTurus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KitapTuruId,KitapTuruAdi,KitapTuruAciklamasi")] KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitapTuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitapTuru);
        }

        // GET: KitapTurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapTuru kitapTuru = db.KitapTurus.Find(id);
            if (kitapTuru == null)
            {
                return HttpNotFound();
            }
            return View(kitapTuru);
        }

        // POST: KitapTurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitapTuru kitapTuru = db.KitapTurus.Find(id);
            db.KitapTurus.Remove(kitapTuru);
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
