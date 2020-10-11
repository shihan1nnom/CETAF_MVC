namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextoBD2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Activo", name: "AmbienteID", newName: "Ambiente_AmbienteID");
            RenameColumn(table: "dbo.Activo", name: "SedeID", newName: "Sede_SedeID");
            RenameIndex(table: "dbo.Activo", name: "IX_AmbienteID", newName: "IX_Ambiente_AmbienteID");
            RenameIndex(table: "dbo.Activo", name: "IX_SedeID", newName: "IX_Sede_SedeID");
            AddColumn("dbo.Ambiente", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ambiente", "Descripcion");
            RenameIndex(table: "dbo.Activo", name: "IX_Sede_SedeID", newName: "IX_SedeID");
            RenameIndex(table: "dbo.Activo", name: "IX_Ambiente_AmbienteID", newName: "IX_AmbienteID");
            RenameColumn(table: "dbo.Activo", name: "Sede_SedeID", newName: "SedeID");
            RenameColumn(table: "dbo.Activo", name: "Ambiente_AmbienteID", newName: "AmbienteID");
        }
    }
}
