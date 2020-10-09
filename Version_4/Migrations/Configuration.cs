namespace Version_4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Version_4.Models.ContextoBD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Version_4.Models.ContextoBD";
        }

        protected override void Seed(Version_4.Models.ContextoBD context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
