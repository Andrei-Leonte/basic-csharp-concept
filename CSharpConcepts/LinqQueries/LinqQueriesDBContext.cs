using Microsoft.EntityFrameworkCore;

namespace LinqQueries
{
    internal class LinqQueriesDBContext : DbContext
    {
        public async Task<IAsyncEnumerable<Book>> RunWhereAge(int age)
        {
            using var context = new LinqQueriesDBContext();

            return context.Books
                .Where(book => book.IsForAdults)
                .AsAsyncEnumerable();
        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("InMemoryDb");
        }

        static void SeedDatabase()
        {
            //using var context = new LinqQueriesDBContext();

            //var books = new List<Book>
            //{
            //    new(1, "Book for Kids", false ),
            //    new (2, "Book for Teens", false ),
            //    new (3, "Book for Adults", true ),
            //    new (4, "Another Book for Adults", true )
            //};

            //context.Books.AddRange(books);

            //var people = new List<Person>
            //{
            //    new (1, "John", 17 ),
            //    new (2, "Jane", 20 )
            //};

            //context.People.AddRange(people);

            //context.SaveChanges();
        }
    }

    public class Person(int id, string name, int age)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
    }

    public class Book(int id, string title, string author, bool isForAdults)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public bool IsForAdults { get; set; } = isForAdults;
    }
}