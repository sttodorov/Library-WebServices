namespace Library.Services.Models
{
    using Library.Model;
    using System;
    using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}