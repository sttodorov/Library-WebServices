namespace Library.Model
{
    using System.Collections.Generic;

    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Genre> genres;
        private ICollection<ApplicationUser> tookenBy;

        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Genres = new HashSet<Genre>();
            this.TookenBy = new HashSet<ApplicationUser>();
            this.Status = Status.Available;

        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public virtual Status Status { get; set; }

        public string Rewiew { get; set; }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }
            set
            {
                this.authors = value;
            }
        }

        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }

        public virtual ICollection<ApplicationUser> TookenBy
        {
            get
            {
                return this.tookenBy;
            }

            set
            {
                this.tookenBy = value;
            }
        }

    }
}
