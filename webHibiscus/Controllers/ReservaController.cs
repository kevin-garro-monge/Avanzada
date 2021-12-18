using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webHibiscus;

namespace webHibiscus.Controllers
{
    public class ReservaController : Controller
    {
        private webHibiscuEntities db = new webHibiscuEntities();

        // GET: Reserva
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.AspNetUser).Include(r => r.AspNetUser1).Include(r => r.Servicio);
            return View(reservas.ToList());
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reserva/Create
        public ActionResult Create(int? id)
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

            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_Empleado = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_Servicio = new SelectList(db.Servicios, "id_Servicio", "nombre", servicio.id_Servicio);

            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Reserva,fecha_Hora,id_Cliente,id_Empleado,id_Servicio")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Cliente);
            ViewBag.id_Empleado = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Empleado);
            ViewBag.id_Servicio = new SelectList(db.Servicios, "id_Servicio", "nombre", reserva.id_Servicio);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Cliente);
            ViewBag.id_Empleado = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Empleado);
            ViewBag.id_Servicio = new SelectList(db.Servicios, "id_Servicio", "nombre", reserva.id_Servicio);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Reserva,fecha_Hora,id_Cliente,id_Empleado,id_Servicio")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Cliente);
            ViewBag.id_Empleado = new SelectList(db.AspNetUsers, "Id", "Email", reserva.id_Empleado);
            ViewBag.id_Servicio = new SelectList(db.Servicios, "id_Servicio", "nombre", reserva.id_Servicio);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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
