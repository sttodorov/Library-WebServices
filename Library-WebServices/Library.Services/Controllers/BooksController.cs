namespace Library.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Library.Data;
    using Library.Model;

    public class BooksController : ApiController
    {
        private ILibraryData data;

        public BooksController()
            : this(new LibraryData())
        {
        }

        public BooksController(ILibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(data.Books.All().Select(a => a.Name));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var book = this.data
                .Books
                .All()
                .Where(s => s.BookId == id)
                .FirstOrDefault();

            if (book == null)
            {
                return BadRequest("Invalid data! Book with such id does not exist.");
            }

            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult Create(Book book)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = new Book
            {
                Name = book.Name,
                Authors = book.Authors,
                Genres = book.Genres,
                Status = book.Status
            };

            this.data.Books.Add(newBook);
            this.data.SaveChanges();

            book.BookId = newBook.BookId;
            return Ok(book);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Book book)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookFromDb = this.data.Books.All().FirstOrDefault(s => s.BookId == id);
            if (bookFromDb == null)
            {
                return BadRequest("Such book does not exists!");
            }

            bookFromDb.Name = book.Name;
            bookFromDb.Authors = book.Authors;
            bookFromDb.Status = book.Status;

            this.data.SaveChanges();

            book.BookId = id;
            return Ok(book);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var bookFromDb = this.data.Books.All().FirstOrDefault(s => s.BookId == id);
            if (bookFromDb == null)
            {
                return BadRequest("Book does not exist!");
            }

            this.data.Books.Delete(bookFromDb);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAuthor(int bookId, int authorId)
        {
            var book = this.data.Books.All().FirstOrDefault(s => s.BookId == bookId);
            if (book == null)
            {
                return BadRequest("Book does not exist - invalid id!");
            }

            var author = this.data.Authors.All().FirstOrDefault(c => c.AuthorId == authorId);
            if (author == null)
            {
                return BadRequest("Author does not exist - invalid id!");
            }

            book.Authors.Add(author);
            this.data.SaveChanges();

            return Ok();
        }
    }
}