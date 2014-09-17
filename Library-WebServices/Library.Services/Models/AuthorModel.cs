namespace Library.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using Library.Model;

    public class AuthorModel
    {
        public static Expression<Func<Author, AuthorModel>> FromAuthor
        {
            get
            {
                return a => new AuthorModel
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                };
            }
        }

        public int AuthorId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string LastName { get; set; }
    }
}