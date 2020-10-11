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
using System.Web.UI.WebControls;

namespace Version_4.Controllers
{
    public class UsuarioController : Controller
    {
        private ContextoBD _bd = new ContextoBD();
        

        public ActionResult Index()
        {
            return View(_bd.Usuarios.ToList());
        }

        public List<SelectListItem> Tipo_Ident()
        {
            List<SelectListItem> _tipo_ident = new List<SelectListItem>();
            _tipo_ident.Add(new SelectListItem() { Text = "Cedula de ciudadania", Value = "1"});
            _tipo_ident.Add(new SelectListItem() { Text = "Cedula de extranjeria", Value = "2" });
            _tipo_ident.Add(new SelectListItem() { Text = "Pasaporte", Value = "3" });
            _tipo_ident.Add(new SelectListItem() { Text = "Tarjeta de identidad", Value = "4" });

            return _tipo_ident;
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario _usuario = _bd.Usuarios.Find(id);
            if (_usuario == null)
            {
                return HttpNotFound();
            }
            return View(_usuario);
        }

        public ActionResult Crear()
        {
            var _tipo_ident = Tipo_Ident();
            ViewBag.TypeIdent = _tipo_ident.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Text
            }).ToList();
            List<Tipo_Usuario> lista = new List<Tipo_Usuario>();
            lista = _bd.Tipo_Usuarios.ToList();
            ViewBag.UserType = lista;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Usuario _usuario)
        {
            if (ModelState.IsValid)
            {
                var check = _bd.Usuarios.FirstOrDefault(s => s.Email == _usuario.Email);
                if (check == null)
                {
                    _usuario.Password = GetMD5(_usuario.Password);
                    _bd.Configuration.ValidateOnSaveEnabled = false;
                    _bd.Usuarios.Add(_usuario);
                    _bd.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El email ya Existe";
                    return View();
                }
            }
            var _tipo_ident = Tipo_Ident();
            ViewBag.TypeIdent = _tipo_ident.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Text
            }).ToList();
            List<Tipo_Usuario> lista = new List<Tipo_Usuario>();
            lista = _bd.Tipo_Usuarios.ToList();
            ViewBag.UserType = lista;
            return View();
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _tipo_ident = Tipo_Ident();
            ViewBag.TypeIdent = _tipo_ident.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Text
            }).ToList();
            List<Tipo_Usuario> lista = new List<Tipo_Usuario>();
            lista = _bd.Tipo_Usuarios.ToList();
            ViewBag.UserType = lista;
            Usuario _usuario = _bd.Usuarios.Find(id);
            if (_usuario == null)
            {
                return HttpNotFound();
            }
            return View(_usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Usuario _usuario)
        {
            if (ModelState.IsValid)
            {
                _usuario.Password = GetMD5(_usuario.Password);
                _bd.Configuration.ValidateOnSaveEnabled = false;
                _bd.Entry(_usuario).State = EntityState.Modified;
                _bd.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                var _tipo_ident = Tipo_Ident();
                ViewBag.TypeIdent = _tipo_ident.Select(x => new SelectListItem
                {
                    Text = x.Text,
                    Value = x.Text
                }).ToList();
                List<Tipo_Usuario> lista = new List<Tipo_Usuario>();
                lista = _bd.Tipo_Usuarios.ToList();
                ViewBag.UserType = lista;
            }
            return View(_usuario);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario _usuario = _bd.Usuarios.Find(id);
            if (_usuario == null)
            {
                return HttpNotFound();
            }
            return View(_usuario);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int? id)
        {
            Usuario _usuario = _bd.Usuarios.Find(id);
            _bd.Usuarios.Remove(_usuario);
            _bd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = _bd.Usuarios.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Nombre + " " + data.FirstOrDefault().Apellido;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UsuarioID"] = data.FirstOrDefault().UsuarioID;
                    return RedirectToAction("Index"); // Controlar pagina despues de Login
                }
                else
                {
                    ViewBag.Error = "Email o Contrseña inconrrecta";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();//Cerrar sesion
            return RedirectToAction("Login", "Usuario");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bd.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}