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
    public class Blood_TypeController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Blood_Type
        public ActionResult Index()
        {
            return View(db.Blood_Type.ToList());
        }

        // GET: Blood_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Type blood_Type = db.Blood_Type.Find(id);
            if (blood_Type == null)
            {
                return HttpNotFound();
            }
            return View(blood_Type);
        }

        // GET: Blood_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blood_Type/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BloodType,Name_Blood")] Blood_Type blood_Type)
        {
            if (ModelState.IsValid)
            {
                db.Blood_Type.Add(blood_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blood_Type);
        }

        // GET: Blood_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Type blood_Type = db.Blood_Type.Find(id);
            if (blood_Type == null)
            {
                return HttpNotFound();
            }
            return View(blood_Type);
        }

        // POST: Blood_Type/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BloodType,Name_Blood")] Blood_Type blood_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blood_Type);
        }

        // GET: Blood_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Type blood_Type = db.Blood_Type.Find(id);
            if (blood_Type == null)
            {
                return HttpNotFound();
            }
            return View(blood_Type);
        }

        // POST: Blood_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_Type blood_Type = db.Blood_Type.Find(id);
            db.Blood_Type.Remove(blood_Type);
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
