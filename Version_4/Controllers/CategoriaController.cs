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
    public class CategoriaController : Controller
    {
        private ContextoBD _bd = new ContextoBD();

        public ActionResult Index()
        {
            return View(_bd.Categorias.ToList());
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria _categoria = _bd.Categorias.Find(id);
            if (_categoria == null)
            {
                return HttpNotFound();
            }
            return View(_categoria);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Categoria _categoria)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Categorias.FirstOrDefault(s => s.Nombre == _categoria.Nombre);
                if (check == null)
                {
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Categorias.Add(_categoria);
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
            Categoria _categoria = _bd.Categorias.Find(id);
            if (_categoria == null)
            {
                return HttpNotFound();
            }
            return View(_categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Categoria _categoria)
        {
            if (ModelState.IsValid)
            {
                _bd.Entry(_categoria).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_categoria);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria _categoria = _bd.Categorias.Find(id);
            if (_categoria == null)
            {
                return HttpNotFound();
            }
            return View(_categoria);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Categoria _categoria = _bd.Categorias.Find(id);
            _bd.Categorias.Remove(_categoria);
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