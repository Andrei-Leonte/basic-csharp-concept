using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public class LinqQueries
    {
        public static void Run()
        {
            using var context = new AppDbContext();

            SeedDatabase(context);

            var people = context.People.ToList();
            
            foreach (var person in people)
            {
                var books = GetBooksBasedOnAge(context.Books, person.Age).ToList();

                Console.WriteLine($"Person {person.Name} with age {person.Age} can get numner of books {books.Count}");
            }
        }

        static IQueryable<Book> GetBooksBasedOnAge(IQueryable<Book> books, int age)
        {
            if (age > 18)
            {
                return books;
            }
            else
            {
                ParameterExpression param = Expression.Parameter(typeof(Book), "b");
                MemberExpression property = Expression.Property(param, nameof(Book.IsForAdults));
                ConstantExpression constant = Expression.Constant(false);
                BinaryExpression body = Expression.Equal(property, constant);
                Expression<Func<Book, bool>> expression = Expression.Lambda<Func<Book, bool>>(body, param);

                return books.Where(expression);
            }
        }

        static void SeedDatabase(AppDbContext context)
        {
            var books = new List<Book>
            {
                new(1, "Book for Kids", false ),
                new (2, "Book for Teens", false ),
                new (3, "Book for Adults", true ),
                new (4, "Another Book for Adults", true )
            };

            context.Books.AddRange(books);

            var people = new List<Person>
            {
                new (1, "John", 17 ),
                new (2, "Jane", 20 )
            };

            context.People.AddRange(people);

            context.SaveChanges();
        }
    }


    public class Person(
        int id, string name, int age)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
    }

    public class Book(int id, string title, bool isForAdults)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public bool IsForAdults { get; set; } = isForAdults;
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
    }
}
