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
    public class UsuarioController : Controller
    {
        private db_a7c3cb_hibicuswebEntities2 db = new db_a7c3cb_hibicuswebEntities2();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Genero).Include(u => u.Rol_Usuario);
            return View(usuarios.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_Genero = new SelectList(db.Generoes, "id_Genero", "Genero1");
            ViewBag.id_Rol_Usuario = new SelectList(db.Rol_Usuario, "id_Rol", "tipo_Rol");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Usuario,id_Rol_Usuario,nombre,apellido1,apellido2,cedula_Usuario,correo,contrasennia,telefono,id_Genero")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Genero = new SelectList(db.Generoes, "id_Genero", "Genero1", usuario.id_Genero);
            ViewBag.id_Rol_Usuario = new SelectList(db.Rol_Usuario, "id_Rol", "tipo_Rol", usuario.id_Rol_Usuario);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Genero = new SelectList(db.Generoes, "id_Genero", "Genero1", usuario.id_Genero);
            ViewBag.id_Rol_Usuario = new SelectList(db.Rol_Usuario, "id_Rol", "tipo_Rol", usuario.id_Rol_Usuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Usuario,id_Rol_Usuario,nombre,apellido1,apellido2,cedula_Usuario,correo,contrasennia,telefono,id_Genero")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Genero = new SelectList(db.Generoes, "id_Genero", "Genero1", usuario.id_Genero);
            ViewBag.id_Rol_Usuario = new SelectList(db.Rol_Usuario, "id_Rol", "tipo_Rol", usuario.id_Rol_Usuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
