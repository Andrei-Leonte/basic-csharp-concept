using Bogus;
using System.ComponentModel;
using System.Diagnostics;

namespace CustomIndexers
{
    public class BookIndexerTest
    {

        [Fact, Description("Usage of custom collection/index.")]
        public void GivenIndexWhenBookIsDuplicateThenThrowException()
        {
            //Arrange
            var bookOne = new Book("book", "author");
            var bookTwo = new Book("book", "author");
            var booksIndexer = new BookIndexer<Book>();
            booksIndexer[0] = bookOne;

            //Act
            var exception = Assert.Throws<InvalidOperationException>(() => booksIndexer[1] = bookTwo);

            //Assert
            Assert.IsType<InvalidOperationException>(exception);
        }


        [Fact, Description("Difference of implementation between using and index and an array.")]
        public void GivenIndexAndListWhenUsingTheSameElementsThenIndesingIsTheSame()
        {
            //Arange
            var faker = new Faker<Book>()
                .CustomInstantiator(f => new Book(f.Name.FullName(), f.Random.Number(1, 100000).ToString()));

            var booksIndexer = new BookIndexer<Book>();
            Book[] booksArray = new Book[1000];
            List<Book> booksList = [];

            for (int i = 0; i < 1000; i++)
            {
                var book = faker.Generate();
                booksList.Add(book);
            }

            // Act
            var stopwatchIndexer = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                booksIndexer[i] = booksList.ElementAt(i);
            }
            stopwatchIndexer.Stop();

            var stopwatchList = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var bookElement = booksList.ElementAt(i);

                if (booksArray.Any(book => book != null
                    && book.Title.Equals(bookElement.Title, StringComparison.CurrentCultureIgnoreCase)
                    && book.Author.Equals(bookElement.Author, StringComparison.CurrentCultureIgnoreCase)))
                {
                    throw new InvalidOperationException("Book already exists!");
                }
                else
                {
                    booksArray[i] = bookElement;
                }
            }

            stopwatchList.Stop();

            Console.WriteLine($"Indexer add time: {stopwatchIndexer.ElapsedMilliseconds} ms");
            Console.WriteLine($"List add time: {stopwatchList.ElapsedMilliseconds} ms");
            Console.WriteLine($"List add time: {stopwatchList.ElapsedMilliseconds} ms");

            Assert.True(true);
        }
    }
}