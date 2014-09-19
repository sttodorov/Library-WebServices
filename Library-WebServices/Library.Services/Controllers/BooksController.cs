﻿namespace Library.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Library.Data;
    using Library.Model;
    using System.Collections.Generic;
    using Library.Services.Models;
    using System.Text;

    public class BooksController : ApiController
    {
        private ILibraryData data;

        public BooksController(ILibraryData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(data.Books.All().Select(BookModel.FromBookAllInfo));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var book = this.data
                .Books
                .All()
                .Select(BookModel.FromBookAllInfo)
                .Where(s => s.BookId == id)
                .FirstOrDefault();

            if (book == null)
            {
                return BadRequest("Invalid data! Book with such id does not exist.");
            }

            return Ok(book);
        }

        [HttpGet]
        public IHttpActionResult ByTitle(string bookTitle)
        {
            var books = this.data.Books.All().Where(a => a.Title.ToLower().Contains(bookTitle.ToLower())).Select(BookModel.FromBookAllInfo);

            return Ok(books);
        }

        [HttpGet]
        public IHttpActionResult ByGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return BadRequest("Genre Required.");
            }
            var booksByGenre = this.data.Books.All()
                                              .Where(b => b.Genres.Any(g => g.Name == genre))
                                              .Select(BookModel.FromBookAllInfo);
            return Ok(booksByGenre);
        }

        [HttpGet]
        public IHttpActionResult ByStatus(Status status)
        {
            var booksByStatus = this.data.Books.All()
                .Select(BookModel.FromBookAllInfo)
                .Where(b => b.Status == status);
            return Ok(booksByStatus);
        }

        [HttpGet]
        public IHttpActionResult TokenBy(int id)
        {
            var book = this.data.Books.All().FirstOrDefault(b => b.BookId == id);
            var users = book.TookenBy.Select(u => new UserModel { Username = u.Email });
            if (users == null )
            {
                return BadRequest("Book with this id does not exists!");
            }

            return Ok(users);
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
                Title = book.Title,
                Rewiew = book.Rewiew

            };

            foreach (var genre in book.Genres)
            {
                var currGenreFromDb = this.data.Genres.All().FirstOrDefault(g => g.Name == genre.Name);
                if (currGenreFromDb == null)
                {
                    currGenreFromDb = new Genre
                    {
                        Name = genre.Name
                    };
                    currGenreFromDb.Books.Add(newBook);
                    this.data.Genres.Add(currGenreFromDb);
                }

                newBook.Genres.Add(currGenreFromDb);
            }

            foreach (var author in book.Authors)
            {
                var currentAuthorFromDb = this.data.Authors.All().FirstOrDefault(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
                if (currentAuthorFromDb == null)
                {
                    currentAuthorFromDb = new Author
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    };
                    currentAuthorFromDb.Books.Add(newBook);
                    this.data.Authors.Add(currentAuthorFromDb);
                }

                newBook.Authors.Add(currentAuthorFromDb);
            }

            this.data.Books.Add(newBook);
            this.data.SaveChanges();

            return Ok(newBook.BookId);
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            var bookFromDb = this.data.Books.All().FirstOrDefault(s => s.BookId == id);
            if (bookFromDb == null)
            {
                return BadRequest("Such book does not exists!");
            }

            if (bookFromDb.Status == Status.Available)
            {
                bookFromDb.Status = Status.Taken;
                bookFromDb.TookenBy.Add(this.data.Users.All().FirstOrDefault(u => u.Id == currentUserId));
            }
            else
            {
                bookFromDb.Status = Status.Available;
            }

            this.data.SaveChanges();
            return Ok("Status chanched!");

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


    }
}