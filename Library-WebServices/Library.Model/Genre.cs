namespace Library.Model
{
    using System.Collections.Generic;

    public class Genre
    {
        private ICollection<Book> books;

        public Genre()
        {
            this.Books = new HashSet<Book>();
        }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }
    }
}
