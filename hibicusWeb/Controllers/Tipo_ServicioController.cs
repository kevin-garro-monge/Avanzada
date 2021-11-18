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
    public class Tipo_ServicioController : Controller
    {
        private db_a7c3cb_hibicuswebEntities2 db = new db_a7c3cb_hibicuswebEntities2();

        // GET: Tipo_Servicio
        public ActionResult Index()
        {
            return View(db.Tipo_Servicio.ToList());
        }

        // GET: Tipo_Servicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servicio tipo_Servicio = db.Tipo_Servicio.Find(id);
            if (tipo_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servicio);
        }

        // GET: Tipo_Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Tipo_Servicio,descripcion")] Tipo_Servicio tipo_Servicio)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Servicio.Add(tipo_Servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Servicio);
        }

        // GET: Tipo_Servicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servicio tipo_Servicio = db.Tipo_Servicio.Find(id);
            if (tipo_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servicio);
        }

        // POST: Tipo_Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Tipo_Servicio,descripcion")] Tipo_Servicio tipo_Servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Servicio);
        }

        // GET: Tipo_Servicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Servicio tipo_Servicio = db.Tipo_Servicio.Find(id);
            if (tipo_Servicio == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Servicio);
        }

        // POST: Tipo_Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Servicio tipo_Servicio = db.Tipo_Servicio.Find(id);
            db.Tipo_Servicio.Remove(tipo_Servicio);
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
