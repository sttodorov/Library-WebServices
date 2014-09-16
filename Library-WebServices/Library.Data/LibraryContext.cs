namespace Library.Data
{
    using System;
    using System.Data.Entity;

    using Library.Model;
    using Library.Data.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    class LibraryContext : IdentityDbContext<User> , ILibraryContext
    {

        public LibraryContext()
            : base("LibraryConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext, Configuration>());
        }

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }

    }
}
