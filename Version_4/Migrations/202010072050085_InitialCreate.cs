namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activo",
                c => new
                    {
                        ActivoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Num_Serie = c.String(nullable: false, maxLength: 50),
                        Fecha_Compra = c.DateTime(nullable: false),
                        Cobertura_Seguro = c.String(nullable: false, maxLength: 100),
                        Valor_Compra = c.Int(nullable: false),
                        Garantia = c.String(nullable: false, maxLength: 100),
                        Fecha_Puesto_Servicio = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Vida_Util = c.String(nullable: false, maxLength: 50),
                        Valor_Residual = c.Int(nullable: false),
                        Ambiente_AmbienteID = c.Int(),
                        Categoria_CategoriaID = c.Int(),
                        Sede_SedeID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivoID)
                .ForeignKey("dbo.Ambiente", t => t.Ambiente_AmbienteID)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaID)
                .ForeignKey("dbo.Sede", t => t.Sede_SedeID)
                .Index(t => t.Ambiente_AmbienteID)
                .Index(t => t.Categoria_CategoriaID)
                .Index(t => t.Sede_SedeID);
            
            CreateTable(
                "dbo.Asignacion",
                c => new
                    {
                        AsignacionesID = c.Int(nullable: false, identity: true),
                        Nombre_Activo = c.String(nullable: false, maxLength: 50),
                        Nombre_Person_Respon = c.String(nullable: false, maxLength: 50),
                        Sede_Asinada = c.String(nullable: false, maxLength: 50),
                        Ambiente_Asignado = c.String(nullable: false, maxLength: 50),
                        Fecha_inicio = c.DateTime(nullable: false),
                        Fecha_Fin = c.DateTime(nullable: false),
                        Activo_ActivoID = c.Int(),
                    })
                .PrimaryKey(t => t.AsignacionesID)
                .ForeignKey("dbo.Activo", t => t.Activo_ActivoID)
                .Index(t => t.Activo_ActivoID);
            
            CreateTable(
                "dbo.Ambiente",
                c => new
                    {
                        AmbienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AmbienteID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        SedeID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Ciudad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SedeID);
            
            CreateTable(
                "dbo.Tipo_Usuario",
                c => new
                    {
                        TipoUserID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Usuario = c.Boolean(nullable: false),
                        Categoria = c.Boolean(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        TipoUser = c.Boolean(nullable: false),
                        Sedes = c.Boolean(nullable: false),
                        Ambientes = c.Boolean(nullable: false),
                        Asignar = c.Boolean(nullable: false),
                        Consulta = c.Boolean(nullable: false),
                        CopiaSeguridad = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoUserID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        TipoIdent = c.String(nullable: false, maxLength: 50),
                        NumIdent = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Tipo_Usuario_TipoUserID = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Tipo_Usuario", t => t.Tipo_Usuario_TipoUserID)
                .Index(t => t.Tipo_Usuario_TipoUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "Tipo_Usuario_TipoUserID", "dbo.Tipo_Usuario");
            DropForeignKey("dbo.Activo", "Sede_SedeID", "dbo.Sede");
            DropForeignKey("dbo.Activo", "Categoria_CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.Activo", "Ambiente_AmbienteID", "dbo.Ambiente");
            DropForeignKey("dbo.Asignacion", "Activo_ActivoID", "dbo.Activo");
            DropIndex("dbo.Usuario", new[] { "Tipo_Usuario_TipoUserID" });
            DropIndex("dbo.Asignacion", new[] { "Activo_ActivoID" });
            DropIndex("dbo.Activo", new[] { "Sede_SedeID" });
            DropIndex("dbo.Activo", new[] { "Categoria_CategoriaID" });
            DropIndex("dbo.Activo", new[] { "Ambiente_AmbienteID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Tipo_Usuario");
            DropTable("dbo.Sede");
            DropTable("dbo.Categoria");
            DropTable("dbo.Ambiente");
            DropTable("dbo.Asignacion");
            DropTable("dbo.Activo");
        }
    }
}
