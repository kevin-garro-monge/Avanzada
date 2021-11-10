using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hibicusWeb;

namespace hibicusWeb.Controllers
{
    public class Rol_UsuarioController : Controller
    {
        private db_a7c3cb_hibicuswebEntities db = new db_a7c3cb_hibicuswebEntities();

        // GET: Rol_Usuario
        public ActionResult Index()
        {
            return View(db.Rol_Usuario.ToList());
        }

        // GET: Rol_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Usuario rol_Usuario = db.Rol_Usuario.Find(id);
            if (rol_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(rol_Usuario);
        }

        // GET: Rol_Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol_Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Rol,tipo_Rol")] Rol_Usuario rol_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Rol_Usuario.Add(rol_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol_Usuario);
        }

        // GET: Rol_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Usuario rol_Usuario = db.Rol_Usuario.Find(id);
            if (rol_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(rol_Usuario);
        }

        // POST: Rol_Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Rol,tipo_Rol")] Rol_Usuario rol_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol_Usuario);
        }

        // GET: Rol_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Usuario rol_Usuario = db.Rol_Usuario.Find(id);
            if (rol_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(rol_Usuario);
        }

        // POST: Rol_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_Usuario rol_Usuario = db.Rol_Usuario.Find(id);
            db.Rol_Usuario.Remove(rol_Usuario);
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
