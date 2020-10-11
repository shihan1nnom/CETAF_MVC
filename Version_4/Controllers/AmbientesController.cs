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
    public class AmbientesController : Controller
    {
        private ContextoBD _bd = new ContextoBD();

        public ActionResult Index()
        {
            return View(_bd.Ambientes.ToList());
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente _ambiente = _bd.Ambientes.Find(id);
            if (_ambiente == null)
            {
                return HttpNotFound();
            }
            return View(_ambiente);
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Ambiente _ambiente)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Ambientes.FirstOrDefault(s => s.Nombre == _ambiente.Nombre);
                if (check == null)
                {
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Ambientes.Add(_ambiente);
                    _bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El nombre del ambiente ya Existe";
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
            Ambiente _ambiente = _bd.Ambientes.Find(id);
            if (_ambiente == null)
            {
                return HttpNotFound();
            }
            return View(_ambiente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Ambiente _ambiente)
        {
            if (ModelState.IsValid)
            {
                _bd.Entry(_ambiente).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_ambiente);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente _ambiente = _bd.Ambientes.Find(id);
            if (_ambiente == null)
            {
                return HttpNotFound();
            }
            return View(_ambiente);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Ambiente _ambiente = _bd.Ambientes.Find(id);
            _bd.Ambientes.Remove(_ambiente);
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