namespace Library.Services.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Library.Model;

    public class BookModel
    {
        private IEnumerable<AuthorModel> authors;
        private IEnumerable<GenreModel> genres;

        public static Expression<Func<Book, BookModel>> FromBookAllInfo
        {
            get
            {
                return book => new BookModel
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Status = book.Status,
                    Rewiew = book.Rewiew,
                    Authors = book.Authors.Select(a => new AuthorModel { AuthorId = a.AuthorId, FirstName = a.FirstName, LastName = a.LastName }),
                    Genres = book.Genres.Select(g => new GenreModel { GenreId = g.GenreId, Name = g.Name })
                };
            }
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public virtual Status Status { get; set; }

        public string Rewiew { get; set; }

        public virtual IEnumerable<AuthorModel> Authors
        {
            get
            {
                return this.authors;
            }
            set
            {
                this.authors = value;
            }
        }

        public virtual IEnumerable<GenreModel> Genres
        {
            get
            {
                return this.genres;
            }
            set
            {
                this.genres = value;
            }
        }
    }
}