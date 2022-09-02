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
    public class Adoption_DetailController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Adoption_Detail
        public ActionResult Index()
        {
            var adoption_Detail = db.Adoption_Detail.Include(a => a.Children);
            return View(adoption_Detail.ToList());
        }

        // GET: Adoption_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption_Detail adoption_Detail = db.Adoption_Detail.Find(id);
            if (adoption_Detail == null)
            {
                return HttpNotFound();
            }
            return View(adoption_Detail);
        }

        // GET: Adoption_Detail/Create
        public ActionResult Create()
        {
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name");
            return View();
        }

        // POST: Adoption_Detail/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_AdoptionDetail,Moving_Date,Adoption_Date,Return_Date,ID_Children")] Adoption_Detail adoption_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Adoption_Detail.Add(adoption_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", adoption_Detail.ID_Children);
            return View(adoption_Detail);
        }

        // GET: Adoption_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption_Detail adoption_Detail = db.Adoption_Detail.Find(id);
            if (adoption_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", adoption_Detail.ID_Children);
            return View(adoption_Detail);
        }

        // POST: Adoption_Detail/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AdoptionDetail,Moving_Date,Adoption_Date,Return_Date,ID_Children")] Adoption_Detail adoption_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoption_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Children = new SelectList(db.Children, "ID_Children", "Name", adoption_Detail.ID_Children);
            return View(adoption_Detail);
        }

        // GET: Adoption_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adoption_Detail adoption_Detail = db.Adoption_Detail.Find(id);
            if (adoption_Detail == null)
            {
                return HttpNotFound();
            }
            return View(adoption_Detail);
        }

        // POST: Adoption_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adoption_Detail adoption_Detail = db.Adoption_Detail.Find(id);
            db.Adoption_Detail.Remove(adoption_Detail);
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
