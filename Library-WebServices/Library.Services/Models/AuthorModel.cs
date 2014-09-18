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
                return author => new AuthorModel
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName
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