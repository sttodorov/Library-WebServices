namespace Library.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Library.Data;
    using Library.Model;
    using Library.Services.Models;

    public class AuthorsController : ApiController
    {
        private ILibraryData data;

        //public AuthorsController()
        //    : this(new LibraryData())
        //{
        //}

        public AuthorsController(ILibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(data.Authors.All().Select(a => a.FirstName + " " + a.LastName));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data
                .Authors
                .All()
                .Where(s => s.AuthorId == id)
                .Select(AuthorModel.FromAuthor)
                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Invalid data! Author with such id does not exist.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(AuthorModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAuthor = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            this.data.Authors.Add(newAuthor);
            this.data.SaveChanges();

            author.AuthorId = newAuthor.AuthorId;
            return Ok(author);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AuthorModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorFromDb = this.data.Authors.All().FirstOrDefault(s => s.AuthorId == id);
            if (authorFromDb == null)
            {
                return BadRequest("Such student does not exist!");
            }

            authorFromDb.FirstName = author.FirstName;
            authorFromDb.LastName = author.LastName;
            this.data.SaveChanges();

            author.AuthorId = id;
            return Ok(author);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var authorFromDb = this.data.Authors.All().FirstOrDefault(s => s.AuthorId == id);
            if (authorFromDb == null)
            {
                return BadRequest("Student does not exist!");
            }

            this.data.Authors.Delete(authorFromDb);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBook(int id, int bookId)
        {
            var author = this.data.Authors.All().FirstOrDefault(s => s.AuthorId == id);
            if (author == null)
            {
                return BadRequest("Author does not exist - invalid id!");
            }

            var book = this.data.Books.All().FirstOrDefault(c => c.BookId == bookId);
            if (book == null)
            {
                return BadRequest("Book does not exist - invalid id!");
            }

            author.Books.Add(book);
            this.data.SaveChanges();

            return Ok();
        }
    }
}