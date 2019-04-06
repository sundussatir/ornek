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
    public class YazarsController : Controller
    {
        private WebApplication5Context db = new WebApplication5Context();

        // GET: Yazars
        public ActionResult Index()
        {
            return View(db.Yazars.ToList());
        }

        // GET: Yazars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazar yazar = db.Yazars.Find(id);
            if (yazar == null)
            {
                return HttpNotFound();
            }
            return View(yazar);
        }

        // GET: Yazars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yazars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YazarId,YazarAdiSoyadi,YazarDogumTarihi")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                db.Yazars.Add(yazar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazar);
        }

        // GET: Yazars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazar yazar = db.Yazars.Find(id);
            if (yazar == null)
            {
                return HttpNotFound();
            }
            return View(yazar);
        }

        // POST: Yazars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YazarId,YazarAdiSoyadi,YazarDogumTarihi")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yazar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yazar);
        }

        // GET: Yazars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yazar yazar = db.Yazars.Find(id);
            if (yazar == null)
            {
                return HttpNotFound();
            }
            return View(yazar);
        }

        // POST: Yazars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yazar yazar = db.Yazars.Find(id);
            db.Yazars.Remove(yazar);
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
