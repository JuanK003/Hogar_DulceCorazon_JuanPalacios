using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hogar_Dulce_Corazón____Juan_Palacios.Models;

namespace Hogar_Dulce_Corazón____Juan_Palacios.Controllers
{
    public class IllnessesController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Illnesses
        public ActionResult Index()
        {
            return View(db.Illness.ToList());
        }

        // GET: Illnesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illness.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // GET: Illnesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Illnesses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Illeness,Description")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Illness.Add(illness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(illness);
        }

        // GET: Illnesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illness.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // POST: Illnesses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Illeness,Description")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(illness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(illness);
        }

        // GET: Illnesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illness.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // POST: Illnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Illness illness = db.Illness.Find(id);
            db.Illness.Remove(illness);
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
