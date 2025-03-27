using Microsoft.EntityFrameworkCore;

namespace LinqQueries.DbContexts
{
    public class LinqQueriesDBContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<PublishingHouse> PublishingHouses => Set<PublishingHouse>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LinqQueriesDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey("Id");
                b.Property(e => e.Name).IsRequired().HasMaxLength(256);
                b.Property(e => e.Age).IsRequired().HasMaxLength(170);
            });

            modelBuilder.Entity<Author>(b =>
            {
                b.HasKey("Id");
                b.Property(e => e.Firstname).IsRequired().HasMaxLength(256);
                b.Property(e => e.Lastname).IsRequired().HasMaxLength(256);
            });

            modelBuilder.Entity<PublishingHouse>(b =>
            {
                b.HasKey("Id");
                b.Property(e => e.Name).IsRequired().HasMaxLength(256);
            });

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey("Id");
                b.Property(e => e.Title).IsRequired().HasMaxLength(256);
                b.Property(e => e.IsForAdults).IsRequired().HasMaxLength(256);
                b.HasOne(e => e.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(e => e.AuthorId);
                b.HasOne(e => e.PublishingHouse)
                    .WithMany(a => a.Books)
                    .HasForeignKey(a => a.PublishingHouseId);
            });

        }
    }

    public class Person(string name, int age)
    {
        public int Id;
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
    }

    public class Book(int authorId, int publishingHouseId, string title, bool isForAdults)
    {
        public int Id;
        public int AuthorId { get; set; } = authorId;
        public int PublishingHouseId { get; set; } = publishingHouseId;
        public string Title { get; set; } = title;
        public bool IsForAdults { get; set; } = isForAdults;
        public Author? Author { get; set; }
        public PublishingHouse? PublishingHouse { get; set; }
    }

    public class Author(string firstname, string lastname)
    {
        public int Id;
        public string Firstname { get; set; } = firstname;
        public string Lastname { get; set; } = lastname;
        public IList<Book> Books { get; set; } = [];
    }

    public class PublishingHouse(string name)
    {
        public int Id;
        public string Name { get; set; } = name;
        public IList<Book> Books { get; set; } = [];
    }
}