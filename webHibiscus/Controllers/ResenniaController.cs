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
    public class ResenniaController : Controller
    {
        private webHibiscuEntities db = new webHibiscuEntities();

        // GET: Resennia
        public ActionResult Index()
        {
            var resennias = db.Resennias.Include(r => r.AspNetUser);
            return View(resennias.ToList());
        }

        // GET: Resennia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resennia resennia = db.Resennias.Find(id);
            if (resennia == null)
            {
                return HttpNotFound();
            }
            return View(resennia);
        }

        // GET: Resennia/Create
        public ActionResult Create()
        {
            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Resennia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Resenia,cotenido,id_Cliente,puntuacion,fecha")] Resennia resennia)
        {
            if (ModelState.IsValid)
            {
                db.Resennias.Add(resennia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", resennia.id_Cliente);
            return View(resennia);
        }

        // GET: Resennia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resennia resennia = db.Resennias.Find(id);
            if (resennia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", resennia.id_Cliente);
            return View(resennia);
        }

        // POST: Resennia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Resenia,cotenido,id_Cliente,puntuacion,fecha")] Resennia resennia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resennia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Cliente = new SelectList(db.AspNetUsers, "Id", "Email", resennia.id_Cliente);
            return View(resennia);
        }

        // GET: Resennia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resennia resennia = db.Resennias.Find(id);
            if (resennia == null)
            {
                return HttpNotFound();
            }
            return View(resennia);
        }

        // POST: Resennia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resennia resennia = db.Resennias.Find(id);
            db.Resennias.Remove(resennia);
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
