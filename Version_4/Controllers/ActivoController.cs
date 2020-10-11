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
    public class ActivoController : Controller
    {
        private ContextoBD _bd = new ContextoBD();

        public ActionResult Index()
        {
            return View(_bd.Activos.ToList());
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activo _activo = _bd.Activos.Find(id);
            if (_activo == null)
            {
                return HttpNotFound();
            }
            return View(_activo);
        }

        public ActionResult Crear()
        {
            List<Categoria> lista = new List<Categoria>();
            lista = _bd.Categorias.ToList();
            ViewBag.Categoria = lista;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Activo _activo)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Activos.FirstOrDefault(s => s.Num_Serie == _activo.Num_Serie);
                if (check == null)
                {
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Activos.Add(_activo);
                    _bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El numero de serie ya Existe";
                    return View();
                }
            }
            List<Categoria> lista = new List<Categoria>();
            lista = _bd.Categorias.ToList();
            ViewBag.Categoria = lista;
            return View();
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Categoria> lista = new List<Categoria>();
            lista = _bd.Categorias.ToList();
            ViewBag.Categoria = lista;
            Activo _activo = _bd.Activos.Find(id);
            if (_activo == null)
            {
                return HttpNotFound();
            }
            return View(_activo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Activo _activo)
        {
            if (ModelState.IsValid)
            {
                _bd.Entry(_activo).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Categoria> lista = new List<Categoria>();
            lista = _bd.Categorias.ToList();
            ViewBag.Categoria = lista;
            return View(_activo);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activo _activo = _bd.Activos.Find(id);
            if (_activo == null)
            {
                return HttpNotFound();
            }
            return View(_activo);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Activo _activo = _bd.Activos.Find(id);
            _bd.Activos.Remove(_activo);
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