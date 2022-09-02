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
    public class ChildrenController : Controller
    {
        private DulceCorazonEntities db = new DulceCorazonEntities();

        // GET: Children
        public ActionResult Index()
        {
            var children = db.Children.Include(c => c.Genre);
            return View(children.ToList());
        }

        // GET: Children/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type");
            return View();
        }

        // POST: Children/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Children,Name,CUI,Date_Birth,ID_Genre")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(children);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", children.ID_Genre);
            return View(children);
        }

        // GET: Children/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", children.ID_Genre);
            return View(children);
        }

        // POST: Children/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Children,Name,CUI,Date_Birth,ID_Genre")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Entry(children).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Genre = new SelectList(db.Genre, "ID_Genre", "Genre_Type", children.ID_Genre);
            return View(children);
        }

        // GET: Children/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Children children = db.Children.Find(id);
            db.Children.Remove(children);
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
