namespace Library.Model
{
    using System.Collections.Generic;

    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Genre> genres;

        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Genres = new HashSet<Genre>();

        }

        public int BookId { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

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

    }
}
