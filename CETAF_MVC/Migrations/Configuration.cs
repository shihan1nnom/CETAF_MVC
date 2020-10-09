namespace CETAF_MVC.Migrations
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<CETAF_MVC.Models.ContextoBD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CETAF_MVC.Models.ContextoBD contexto)
        {
            var usuarios = new List<Models.Usuario>
            {
                new Models.Usuario
                {
                    //UsuarioID = 1,
                    Nombre = "Administrador",
                    Apellido = "Admin",
                    Email = "admin@admin.com",
                    Password = GetMD5("Darkseven-7"),
                    ConfirmPassword = GetMD5("Darkseven-7")

                },
                new Models.Usuario
                {
                    //UsuarioID = 1,
                    Nombre = "Auxiliar",
                    Apellido = "Admin",
                    Email = "auxi@auxi.com",
                    Password = GetMD5("Darkseven-7"),
                    ConfirmPassword = GetMD5("Darkseven-7")
                },
            };
            usuarios.ForEach(u => contexto.Usuarios.Add(u));
            //contexto.SaveChanges();
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
