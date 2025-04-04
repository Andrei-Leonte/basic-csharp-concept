using LinqQueries.DbContexts;

namespace LinqQueries.Migrations
{
    public class DataSeeder
    {
         private const int NumberOfRecords = 1_000_000;

        public static void SeedData(LinqQueriesDBContext context)
        {
            var people = DataGenerator.GeneratePeople(NumberOfRecords);
            var authors = DataGenerator.GenerateAuthors(NumberOfRecords);
            var publishingHouses = DataGenerator.GeneratePublishingHouse(NumberOfRecords);

            context.People.AddRange(people);
            context.Authors.AddRange(authors);
            context.PublishingHouses.AddRange(publishingHouses);

            context.SaveChanges();
            
            var books = DataGenerator.GenerateBooks(NumberOfRecords, authors, publishingHouses);
            context.Books.AddRange(books);

            context.SaveChanges();
        }
    }
}