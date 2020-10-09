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
using System.Security.Cryptography;
using System.Data.Entity.Migrations;

namespace Version_4.Controllers
{
    public class TipoUserController : Controller
    {
        private ContextoBD _bd = new ContextoBD();

        public ActionResult Index()
        {
            return View(_bd.Tipo_Usuarios.ToList());
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario _tipo_user = _bd.Tipo_Usuarios.Find(id);
            if (_tipo_user == null)
            {
                return HttpNotFound();
            }
            return View(_tipo_user);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Tipo_Usuario _tipo_user)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Tipo_Usuarios.FirstOrDefault(s => s.Nombre == _tipo_user.Nombre);
                if (check == null)
                {
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Tipo_Usuarios.Add(_tipo_user);
                    _bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El nombre de tipo usuario ya Existe";
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
            Tipo_Usuario _tipo_user = _bd.Tipo_Usuarios.Find(id);
            if (_tipo_user == null)
            {
                return HttpNotFound();
            }
            return View(_tipo_user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Tipo_Usuario _tipo_user)
        {
            if (ModelState.IsValid)
            {
                _bd.Entry(_tipo_user).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_tipo_user);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Usuario _tipo_user = _bd.Tipo_Usuarios.Find(id);
            if (_tipo_user == null)
            {
                return HttpNotFound();
            }
            return View(_tipo_user);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Tipo_Usuario _tipo_user = _bd.Tipo_Usuarios.Find(id);
            _bd.Tipo_Usuarios.Remove(_tipo_user);
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