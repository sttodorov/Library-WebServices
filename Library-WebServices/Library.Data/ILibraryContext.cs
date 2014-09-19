namespace Library.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Library.Model;

    public interface ILibraryContext
    {
        IDbSet<Author> Authors { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
