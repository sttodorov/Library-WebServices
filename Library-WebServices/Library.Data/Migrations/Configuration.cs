namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.LibraryContext>
    {
        public Configuration()
        {
            ContextKey = "Library.Data.LibraryContext";
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Library.Data.LibraryContext context)
        {
        }
    }
}
