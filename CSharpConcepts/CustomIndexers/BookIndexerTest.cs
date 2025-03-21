using Bogus;
using System.Diagnostics;

namespace CustomIndexers
{
    public class BookIndexerTest
    {
        [Fact]
        public void Test1()
        {
            //Arange

            var faker = new Faker<Book>()
                .CustomInstantiator(f => new Book(f.Name.FullName(), f.Random.Number(1, 100000).ToString()));

            var booksIndexer = new BookIndexer<Book>();
            var booksList = new List<Book>();

            // Act
            var stopwatchIndexer = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                booksIndexer[i] = faker.Generate();
            }
            stopwatchIndexer.Stop();

            var stopwatchList = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                booksList.Add(faker.Generate());
            }

            stopwatchList.Stop();

            Console.WriteLine($"Indexer add time: {stopwatchIndexer.ElapsedMilliseconds} ms");
            Console.WriteLine($"List add time: {stopwatchList.ElapsedMilliseconds} ms");
            Console.WriteLine($"List add time: {stopwatchList.ElapsedMilliseconds} ms");
        }
    }
}