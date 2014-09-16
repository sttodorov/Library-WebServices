namespace Library.Data
{
    using Library.Model;
    using Library.Data.Repositories;

    public interface ILibraryData
    {
        IGenericRepository<Author> Authors { get; }
        IGenericRepository<Book> Books { get; }
        IGenericRepository<Genre> Genres { get; }
    }
}
