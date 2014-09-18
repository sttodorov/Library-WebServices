namespace Library.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Library.Data;
    using Library.Services.Models;
    using Library.Model;

    public class GenresController : ApiController
    {
        private ILibraryData data;

        public GenresController(ILibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var genres = this.data.Genres.All().Select(GenreModel.FromGenre);

            return Ok(genres);
        }

        [HttpPost]
        public IHttpActionResult Create(GenreModel genre)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGenre = new Genre
            {
                Name = genre.Name
            };

            this.data.Genres.Add(newGenre);
            this.data.SaveChanges();

            genre.GenreId = newGenre.GenreId;
            return Ok(genre);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, GenreModel genre)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genreFromDb = this.data.Genres.All().FirstOrDefault(s => s.GenreId == id);
            if (genreFromDb == null)
            {
                return BadRequest("Such genre does not exist!");
            }

            genreFromDb.Name = genre.Name;
            this.data.SaveChanges();

            genre.GenreId = id;

            return Ok(genre);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var genreFromDb = this.data.Genres.All().FirstOrDefault(s => s.GenreId == id);
            if (genreFromDb == null)
            {
                return BadRequest("Student does not exist!");
            }

            this.data.Genres.Delete(genreFromDb);
            this.data.SaveChanges();

            return Ok();
        }
        
        [HttpPost]
        public IHttpActionResult AddBook(int id, int bookId)
        {
            var genre = this.data.Genres.All().FirstOrDefault(s => s.GenreId == id);
            if (genre == null)
            {
                return BadRequest("Genre does not exist - invalid id!");
            }

            var book = this.data.Books.All().FirstOrDefault(c => c.BookId == bookId);
            if (book == null)
            {
                return BadRequest("Book does not exist - invalid id!");
            }

            genre.Books.Add(book);
            this.data.SaveChanges();

            return Ok();
        }
    }
}