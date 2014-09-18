namespace Library.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using Library.Model;

    public class GenreModel
    {
        public static Expression<Func<Genre, GenreModel>> FromGenre
        {
            get
            {
                return genre => new GenreModel
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name
                };
            }
        }

        public int GenreId { get; set; }

        public string Name { get; set; }
    }
}