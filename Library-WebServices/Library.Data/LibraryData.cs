using Library.Data.Repositories;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public class LibraryData : ILibraryData
    {
        private ILibraryContext context;

        private IDictionary<Type, object> repositories;

        public LibraryData()
            : this(new LibraryContext())
        {
        }

        public LibraryData(ILibraryContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IGenericRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IGenericRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IGenericRepository<Genre> Genres
        {
            get
            {
                return this.GetRepository<Genre>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
