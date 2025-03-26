using Bogus;
using Newtonsoft.Json;

namespace LinqQueries
{
    public class SeedTest
    {
        [Fact]
        public void Test1()
        {
            var personFaker = new Faker<Person>()
                .CustomInstantiator(factory =>
                    new Person(0, factory.Name.FullName(), factory.Random.Int(18, 65)));

            var bookFaker = new Faker<Book>()
                .CustomInstantiator(factory =>
                    new Book(0, factory.Lorem.Sentence(), factory.Name.FullName(), factory.Random.Bool()));

            var persons = personFaker.Generate(1000);
            var books = bookFaker.Generate(1000);

            File.WriteAllText("persons.json", JsonConvert.SerializeObject(persons, Formatting.Indented));
            File.WriteAllText("books.json", JsonConvert.SerializeObject(books, Formatting.Indented));
        }
    }
}