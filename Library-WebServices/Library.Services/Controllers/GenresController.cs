namespace Library.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;    

    using Library.Data;
    using Library.Model;


    public class GenresController : ApiController
    {
        private ILibraryData data;

        [HttpGet]
        public IHttpActionResult All()
        {
            //var currentUserId = this.User.Identity.GetUserId();

            var genres = this.data.Genres.All();
            return Ok(genres);
        }

    }
}