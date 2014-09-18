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
        private ICollection<Author> authors;


         public static Expression<Func<Book, BookModel>> FromBook
        {
            get
            {
                return b => new BookModel
                {
                     Name = b.Name,
                     Status = b.Status,
                     BookId = b.BookId,
                     Authors = b.Authors
                };
            }
        }


        public int BookId { get; set; }

        public string Name { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Author> Authors
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
    }
}