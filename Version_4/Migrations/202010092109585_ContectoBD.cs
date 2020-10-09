namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContectoBD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categoria", "Descripcion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categoria", "Descripcion");
        }
    }
}
