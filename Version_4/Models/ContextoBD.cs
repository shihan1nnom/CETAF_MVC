using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Version_4.Models
{
    public class ContextoBD:DbContext
    {
        public ContextoBD() : base("BD_CETAF") { } // Especificar nombre de la conexion String

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo_Usuario> Tipo_Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Tipo_Usuario>().ToTable("Tipo_Usuario");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Sede>().ToTable("Sede");
            modelBuilder.Entity<Ambiente>().ToTable("Ambiente");
            modelBuilder.Entity<Activo>().ToTable("Activo");
            modelBuilder.Entity<Asignacion>().ToTable("Asignacion");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}