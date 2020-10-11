namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextoBD3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activo", "Fecha_Compra", c => c.String(nullable: false));
            AlterColumn("dbo.Activo", "Cobertura_Seguro", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Activo", "Valor_Compra", c => c.String(nullable: false));
            AlterColumn("dbo.Activo", "Garantia", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Activo", "Fecha_Puesto_Servicio", c => c.String(nullable: false));
            AlterColumn("dbo.Activo", "Vida_Util", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Activo", "Valor_Residual", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activo", "Valor_Residual", c => c.Int(nullable: false));
            AlterColumn("dbo.Activo", "Vida_Util", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Activo", "Fecha_Puesto_Servicio", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Activo", "Garantia", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Activo", "Valor_Compra", c => c.Int(nullable: false));
            AlterColumn("dbo.Activo", "Cobertura_Seguro", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Activo", "Fecha_Compra", c => c.DateTime(nullable: false));
        }
    }
}
