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
    public class KitapsController : Controller
    {
        private WebApplication5Context db = new WebApplication5Context();

        // GET: Kitaps
        public ActionResult Index()
        {
            var kitaps = db.Kitaps.Include(k => k.KitabinTuru).Include(k => k.Yazari);
            return View(kitaps.ToList());
        }

        // GET: Kitaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = db.Kitaps.Find(id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            return View(kitap);
        }

        // GET: Kitaps/Create
        public ActionResult Create()
        {
            ViewBag.KitapTuruId = new SelectList(db.KitapTurus, "KitapTuruId", "KitapTuruAdi");
            ViewBag.YazarId = new SelectList(db.Yazars, "YazarId", "YazarAdiSoyadi");
            return View();
        }

        // POST: Kitaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KitapId,KitapAdi,KitapBasimTarihi,YazarId,KitapTuruId")] Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                db.Kitaps.Add(kitap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KitapTuruId = new SelectList(db.KitapTurus, "KitapTuruId", "KitapTuruAdi", kitap.KitapTuruId);
            ViewBag.YazarId = new SelectList(db.Yazars, "YazarId", "YazarAdiSoyadi", kitap.YazarId);
            return View(kitap);
        }

        // GET: Kitaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = db.Kitaps.Find(id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            ViewBag.KitapTuruId = new SelectList(db.KitapTurus, "KitapTuruId", "KitapTuruAdi", kitap.KitapTuruId);
            ViewBag.YazarId = new SelectList(db.Yazars, "YazarId", "YazarAdiSoyadi", kitap.YazarId);
            return View(kitap);
        }

        // POST: Kitaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KitapId,KitapAdi,KitapBasimTarihi,YazarId,KitapTuruId")] Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KitapTuruId = new SelectList(db.KitapTurus, "KitapTuruId", "KitapTuruAdi", kitap.KitapTuruId);
            ViewBag.YazarId = new SelectList(db.Yazars, "YazarId", "YazarAdiSoyadi", kitap.YazarId);
            return View(kitap);
        }

        // GET: Kitaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitap kitap = db.Kitaps.Find(id);
            if (kitap == null)
            {
                return HttpNotFound();
            }
            return View(kitap);
        }

        // POST: Kitaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitap kitap = db.Kitaps.Find(id);
            db.Kitaps.Remove(kitap);
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
