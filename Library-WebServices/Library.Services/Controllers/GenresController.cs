namespace Library.Services.Controllers
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Web.Http;
    using Library.Data;
    using Library.Services.Models;

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


    }
}