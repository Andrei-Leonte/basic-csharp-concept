using Bogus;
using LinqQueries.DbContexts;
using Person = LinqQueries.DbContexts.Person;

namespace LinqQueries.Migrations
{
    public static class DataGenerator
    {
        public static List<Person> GeneratePeople(int count)
        {
            var personFaker = new Faker<Person>()
                .CustomInstantiator(f => new Person(
                    f.Name.FullName(),
                    f.Random.Int(0, 100)
                ));

            return personFaker.Generate(count);
        }

        public static List<Author> GenerateAuthors(int count)
        {
            var authorFaker = new Faker<Author>()
                .CustomInstantiator(f => new Author(
                    f.Name.FirstName(),
                    f.Name.LastName()
                ));

            return authorFaker.Generate(count);
        }

        public static List<PublishingHouse> GeneratePublishingHouse(int count)
        {
            var publishingHouse = new Faker<PublishingHouse>()
                .CustomInstantiator(f => new PublishingHouse(
                    f.Company.CompanyName()
                ));

            return publishingHouse.Generate(count);
        }

        public static List<Book> GenerateBooks(int count, IList<Author> authors, IList<PublishingHouse> publishingHouses)
        {
            var bookFaker = new Faker<Book>()
                .CustomInstantiator(f => new Book(
                    f.PickRandom(authors).Id,
                    f.PickRandom(publishingHouses).Id,
                    f.Lorem.Word(),
                    f.Random.Bool()
                ));

            return bookFaker.Generate(count);
        }
    }
}