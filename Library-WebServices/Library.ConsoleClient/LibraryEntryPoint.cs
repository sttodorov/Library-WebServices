namespace Library.ConsoleClient
{
    using System;
    using System.Linq;

    using Library.Data;
    using Library.Model;

    public class LibraryEntryPoint
    {
        static void Main()
        {
            var Database = new LibraryData();

            Database.Authors.Add(new Author
            {
                FirstName = "Qwerty",
                LastName = "Wasd"
            });

            Database.SaveChanges();

            var authorsFromDb = Database.Authors.All();

            foreach (var author in authorsFromDb)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }
    }
}
