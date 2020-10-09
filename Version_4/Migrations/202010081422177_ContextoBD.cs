namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextoBD : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Asignacion", name: "Activo_ActivoID", newName: "ActivoID");
            RenameColumn(table: "dbo.Activo", name: "Ambiente_AmbienteID", newName: "AmbienteID");
            RenameColumn(table: "dbo.Activo", name: "Categoria_CategoriaID", newName: "CategoriaID");
            RenameColumn(table: "dbo.Activo", name: "Sede_SedeID", newName: "SedeID");
            RenameColumn(table: "dbo.Usuario", name: "Tipo_Usuario_TipoUserID", newName: "TipoUserID");
            RenameIndex(table: "dbo.Activo", name: "IX_Categoria_CategoriaID", newName: "IX_CategoriaID");
            RenameIndex(table: "dbo.Activo", name: "IX_Sede_SedeID", newName: "IX_SedeID");
            RenameIndex(table: "dbo.Activo", name: "IX_Ambiente_AmbienteID", newName: "IX_AmbienteID");
            RenameIndex(table: "dbo.Asignacion", name: "IX_Activo_ActivoID", newName: "IX_ActivoID");
            RenameIndex(table: "dbo.Usuario", name: "IX_Tipo_Usuario_TipoUserID", newName: "IX_TipoUserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Usuario", name: "IX_TipoUserID", newName: "IX_Tipo_Usuario_TipoUserID");
            RenameIndex(table: "dbo.Asignacion", name: "IX_ActivoID", newName: "IX_Activo_ActivoID");
            RenameIndex(table: "dbo.Activo", name: "IX_AmbienteID", newName: "IX_Ambiente_AmbienteID");
            RenameIndex(table: "dbo.Activo", name: "IX_SedeID", newName: "IX_Sede_SedeID");
            RenameIndex(table: "dbo.Activo", name: "IX_CategoriaID", newName: "IX_Categoria_CategoriaID");
            RenameColumn(table: "dbo.Usuario", name: "TipoUserID", newName: "Tipo_Usuario_TipoUserID");
            RenameColumn(table: "dbo.Activo", name: "SedeID", newName: "Sede_SedeID");
            RenameColumn(table: "dbo.Activo", name: "CategoriaID", newName: "Categoria_CategoriaID");
            RenameColumn(table: "dbo.Activo", name: "AmbienteID", newName: "Ambiente_AmbienteID");
            RenameColumn(table: "dbo.Asignacion", name: "ActivoID", newName: "Activo_ActivoID");
        }
    }
}
