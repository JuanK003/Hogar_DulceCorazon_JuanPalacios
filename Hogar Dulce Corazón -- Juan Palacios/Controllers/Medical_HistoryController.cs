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
    public class Medical_HistoryController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Medical_History
        public ActionResult Index()
        {
            var medical_History = db.Medical_History.Include(m => m.Blood_Type).Include(m => m.Children).Include(m => m.Illness);
            return View(medical_History.ToList());
        }

        // GET: Medical_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_History medical_History = db.Medical_History.Find(id);
            if (medical_History == null)
            {
                return HttpNotFound();
            }
            return View(medical_History);
        }

        // GET: Medical_History/Create
        public ActionResult Create()
        {
            ViewBag.ID_BloodType = new SelectList(db.Blood_Type, "ID_BloodType", "Name_Blood");
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name");
            ViewBag.ID_Illeness = new SelectList(db.Illness, "ID_Illeness", "Description");
            return View();
        }

        // POST: Medical_History/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MedicalHistory,ID_Children,Description,ID_Illeness,Treatment,Evaluation_Date,ID_BloodType")] Medical_History medical_History)
        {
            if (ModelState.IsValid)
            {
                db.Medical_History.Add(medical_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BloodType = new SelectList(db.Blood_Type, "ID_BloodType", "Name_Blood", medical_History.ID_BloodType);
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", medical_History.ID_Children);
            ViewBag.ID_Illeness = new SelectList(db.Illness, "ID_Illeness", "Description", medical_History.ID_Illeness);
            return View(medical_History);
        }

        // GET: Medical_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_History medical_History = db.Medical_History.Find(id);
            if (medical_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BloodType = new SelectList(db.Blood_Type, "ID_BloodType", "Name_Blood", medical_History.ID_BloodType);
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", medical_History.ID_Children);
            ViewBag.ID_Illeness = new SelectList(db.Illness, "ID_Illeness", "Description", medical_History.ID_Illeness);
            return View(medical_History);
        }

        // POST: Medical_History/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MedicalHistory,ID_Children,Description,ID_Illeness,Treatment,Evaluation_Date,ID_BloodType")] Medical_History medical_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BloodType = new SelectList(db.Blood_Type, "ID_BloodType", "Name_Blood", medical_History.ID_BloodType);
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", medical_History.ID_Children);
            ViewBag.ID_Illeness = new SelectList(db.Illness, "ID_Illeness", "Description", medical_History.ID_Illeness);
            return View(medical_History);
        }

        // GET: Medical_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_History medical_History = db.Medical_History.Find(id);
            if (medical_History == null)
            {
                return HttpNotFound();
            }
            return View(medical_History);
        }

        // POST: Medical_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medical_History medical_History = db.Medical_History.Find(id);
            db.Medical_History.Remove(medical_History);
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
