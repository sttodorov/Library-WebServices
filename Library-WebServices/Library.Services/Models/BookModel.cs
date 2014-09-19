using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Library.Services.Models
{
    public class BookModel
    {
        private IEnumerable<AuthorModel> authors;
        private IEnumerable<GenreModel> genres;


         public static Expression<Func<Book, BookModel>> FromBookAllInfo
        {
            get
            {
                return b => new BookModel
                {
                    Title = b.Title,
                    Status = b.Status,
                    BookId = b.BookId,
                    Authors = b.Authors.Select(a => new AuthorModel {AuthorId= a.AuthorId, FirstName = a.FirstName, LastName = a.LastName }),
                    Genres = b.Genres.Select(g => new GenreModel { GenreId = g.GenreId, Name = g.Name })
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