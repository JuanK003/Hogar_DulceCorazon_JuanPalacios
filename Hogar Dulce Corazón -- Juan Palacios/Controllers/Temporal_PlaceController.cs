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
    public class Temporal_PlaceController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Temporal_Place
        public ActionResult Index()
        {
            var temporal_Place = db.Temporal_Place.Include(t => t.Children).Include(t => t.Temporary_Caregiver);
            return View(temporal_Place.ToList());
        }

        // GET: Temporal_Place/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporal_Place temporal_Place = db.Temporal_Place.Find(id);
            if (temporal_Place == null)
            {
                return HttpNotFound();
            }
            return View(temporal_Place);
        }

        // GET: Temporal_Place/Create
        public ActionResult Create()
        {
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name");
            ViewBag.ID_TemporaryCaregiver = new SelectList(db.Temporary_Caregiver, "ID_TemporaryCaregiver", "Name");
            return View();
        }

        // POST: Temporal_Place/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TemporalPlace,Address,Cellphone,ID_Children,ID_TemporaryCaregiver")] Temporal_Place temporal_Place)
        {
            if (ModelState.IsValid)
            {
                db.Temporal_Place.Add(temporal_Place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", temporal_Place.ID_Children);
            ViewBag.ID_TemporaryCaregiver = new SelectList(db.Temporary_Caregiver, "ID_TemporaryCaregiver", "Name", temporal_Place.ID_TemporaryCaregiver);
            return View(temporal_Place);
        }

        // GET: Temporal_Place/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporal_Place temporal_Place = db.Temporal_Place.Find(id);
            if (temporal_Place == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", temporal_Place.ID_Children);
            ViewBag.ID_TemporaryCaregiver = new SelectList(db.Temporary_Caregiver, "ID_TemporaryCaregiver", "Name", temporal_Place.ID_TemporaryCaregiver);
            return View(temporal_Place);
        }

        // POST: Temporal_Place/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TemporalPlace,Address,Cellphone,ID_Children,ID_TemporaryCaregiver")] Temporal_Place temporal_Place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporal_Place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", temporal_Place.ID_Children);
            ViewBag.ID_TemporaryCaregiver = new SelectList(db.Temporary_Caregiver, "ID_TemporaryCaregiver", "Name", temporal_Place.ID_TemporaryCaregiver);
            return View(temporal_Place);
        }

        // GET: Temporal_Place/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporal_Place temporal_Place = db.Temporal_Place.Find(id);
            if (temporal_Place == null)
            {
                return HttpNotFound();
            }
            return View(temporal_Place);
        }

        // POST: Temporal_Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temporal_Place temporal_Place = db.Temporal_Place.Find(id);
            db.Temporal_Place.Remove(temporal_Place);
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
