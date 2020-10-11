using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Version_4.Models;
using System.Data.Entity.Migrations;

namespace Version_4.Controllers
{
    public class SedesController : Controller
    {
        private ContextoBD _bd = new ContextoBD();

        public ActionResult Index()
        {
            return View(_bd.Sedes.ToList());
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede _sede = _bd.Sedes.Find(id);
            if (_sede == null)
            {
                return HttpNotFound();
            }
            return View(_sede);
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Sede _sede)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Sedes.FirstOrDefault(s => s.Nombre == _sede.Nombre);
                if (check == null)
                {
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Sedes.Add(_sede);
                    _bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El nombre de la categoria ya Existe";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede _sede = _bd.Sedes.Find(id);
            if (_sede == null)
            {
                return HttpNotFound();
            }
            return View(_sede);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Sede _sede)
        {
            if (ModelState.IsValid)
            {
                _bd.Entry(_sede).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_sede);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede _sede = _bd.Sedes.Find(id);
            if (_sede == null)
            {
                return HttpNotFound();
            }
            return View(_sede);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Sede _sede = _bd.Sedes.Find(id);
            _bd.Sedes.Remove(_sede);
            _bd.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}