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
    public class Temporary_CaregiverController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Temporary_Caregiver
        public ActionResult Index()
        {
            return View(db.Temporary_Caregiver.ToList());
        }

        // GET: Temporary_Caregiver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporary_Caregiver temporary_Caregiver = db.Temporary_Caregiver.Find(id);
            if (temporary_Caregiver == null)
            {
                return HttpNotFound();
            }
            return View(temporary_Caregiver);
        }

        // GET: Temporary_Caregiver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temporary_Caregiver/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TemporaryCaregiver,Name,Address,Cellphone,Email")] Temporary_Caregiver temporary_Caregiver)
        {
            if (ModelState.IsValid)
            {
                db.Temporary_Caregiver.Add(temporary_Caregiver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temporary_Caregiver);
        }

        // GET: Temporary_Caregiver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporary_Caregiver temporary_Caregiver = db.Temporary_Caregiver.Find(id);
            if (temporary_Caregiver == null)
            {
                return HttpNotFound();
            }
            return View(temporary_Caregiver);
        }

        // POST: Temporary_Caregiver/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TemporaryCaregiver,Name,Address,Cellphone,Email")] Temporary_Caregiver temporary_Caregiver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporary_Caregiver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temporary_Caregiver);
        }

        // GET: Temporary_Caregiver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporary_Caregiver temporary_Caregiver = db.Temporary_Caregiver.Find(id);
            if (temporary_Caregiver == null)
            {
                return HttpNotFound();
            }
            return View(temporary_Caregiver);
        }

        // POST: Temporary_Caregiver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temporary_Caregiver temporary_Caregiver = db.Temporary_Caregiver.Find(id);
            db.Temporary_Caregiver.Remove(temporary_Caregiver);
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
