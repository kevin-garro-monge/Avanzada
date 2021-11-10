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
    public class ServicioController : Controller
    {
        private db_a7c3cb_hibicuswebEntities db = new db_a7c3cb_hibicuswebEntities();

        // GET: Servicio
        public ActionResult Index()
        {
            var servicios = db.Servicios.Include(s => s.Tipo_Servicio);
            return View(servicios.ToList());
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.id_Tipo_Servicio = new SelectList(db.Tipo_Servicio, "id_Tipo_Servicio", "descripcion");
            return View();
        }

        // POST: Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Servicio,id_Tipo_Servicio,descripcion,precio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Tipo_Servicio = new SelectList(db.Tipo_Servicio, "id_Tipo_Servicio", "descripcion", servicio.id_Tipo_Servicio);
            return View(servicio);
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Tipo_Servicio = new SelectList(db.Tipo_Servicio, "id_Tipo_Servicio", "descripcion", servicio.id_Tipo_Servicio);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Servicio,id_Tipo_Servicio,descripcion,precio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Tipo_Servicio = new SelectList(db.Tipo_Servicio, "id_Tipo_Servicio", "descripcion", servicio.id_Tipo_Servicio);
            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicios.Find(id);
            db.Servicios.Remove(servicio);
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
