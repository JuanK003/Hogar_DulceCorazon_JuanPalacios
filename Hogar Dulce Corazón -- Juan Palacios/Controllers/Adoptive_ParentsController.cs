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
    public class Adoptive_ParentsController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Adoptive_Parents
        public ActionResult Index()
        {
            var adoptive_Parents = db.Adoptive_Parents.Include(a => a.Adoption_Detail).Include(a => a.Genre).Include(a => a.Medical_History);
            return View(adoptive_Parents.ToList());
        }

        // GET: Adoptive_Parents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptive_Parents adoptive_Parents = db.Adoptive_Parents.Find(id);
            if (adoptive_Parents == null)
            {
                return HttpNotFound();
            }
            return View(adoptive_Parents);
        }

        // GET: Adoptive_Parents/Create
        public ActionResult Create()
        {
            ViewBag.ID_AdoptionDetail = new SelectList(db.Adoption_Detail, "ID_AdoptionDetail", "ID_AdoptionDetail");
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type");
            ViewBag.ID_MedicalHistory = new SelectList(db.Medical_History, "ID_MedicalHistory", "Description");
            return View();
        }

        // POST: Adoptive_Parents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_AdoptiveParents,Name,Address,Email,Cellphone,Work_Address,ID_Genre,ID_MedicalHistory,ID_AdoptionDetail")] Adoptive_Parents adoptive_Parents)
        {
            if (ModelState.IsValid)
            {
                db.Adoptive_Parents.Add(adoptive_Parents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AdoptionDetail = new SelectList(db.Adoption_Detail, "ID_AdoptionDetail", "ID_AdoptionDetail", adoptive_Parents.ID_AdoptionDetail);
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", adoptive_Parents.ID_Genre);
            ViewBag.ID_MedicalHistory = new SelectList(db.Medical_History, "ID_MedicalHistory", "Description", adoptive_Parents.ID_MedicalHistory);
            return View(adoptive_Parents);
        }

        // GET: Adoptive_Parents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptive_Parents adoptive_Parents = db.Adoptive_Parents.Find(id);
            if (adoptive_Parents == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AdoptionDetail = new SelectList(db.Adoption_Detail, "ID_AdoptionDetail", "ID_AdoptionDetail", adoptive_Parents.ID_AdoptionDetail);
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", adoptive_Parents.ID_Genre);
            ViewBag.ID_MedicalHistory = new SelectList(db.Medical_History, "ID_MedicalHistory", "Description", adoptive_Parents.ID_MedicalHistory);
            return View(adoptive_Parents);
        }

        // POST: Adoptive_Parents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AdoptiveParents,Name,Address,Email,Cellphone,Work_Address,ID_Genre,ID_MedicalHistory,ID_AdoptionDetail")] Adoptive_Parents adoptive_Parents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptive_Parents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AdoptionDetail = new SelectList(db.Adoption_Detail, "ID_AdoptionDetail", "ID_AdoptionDetail", adoptive_Parents.ID_AdoptionDetail);
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", adoptive_Parents.ID_Genre);
            ViewBag.ID_MedicalHistory = new SelectList(db.Medical_History, "ID_MedicalHistory", "Description", adoptive_Parents.ID_MedicalHistory);
            return View(adoptive_Parents);
        }

        // GET: Adoptive_Parents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoptive_Parents adoptive_Parents = db.Adoptive_Parents.Find(id);
            if (adoptive_Parents == null)
            {
                return HttpNotFound();
            }
            return View(adoptive_Parents);
        }

        // POST: Adoptive_Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adoptive_Parents adoptive_Parents = db.Adoptive_Parents.Find(id);
            db.Adoptive_Parents.Remove(adoptive_Parents);
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
