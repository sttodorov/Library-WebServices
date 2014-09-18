namespace Library.Services.Models
{
    using Library.Model;
    using System;
    using System.Linq.Expressions;
    public class GenreModel
    {
        public static Expression<Func<Genre, GenreModel>> FromGenre
        {
            get
            {
                return g => new GenreModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name
                };
            }
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}