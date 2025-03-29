using LinqQueries.DbContexts;
using LinqQueriesConsole.PartialEntities;
using Microsoft.EntityFrameworkCore;

namespace LinqQueriesConsole.Repositories
{
    public class CollectionSizeBookRespository
    {
        public static async Task<List<EagerBook>> GetEagerListAllAdultBookUsingSelectAsync()
        {
            using var context = new LinqQueriesDBContext();

            return await context.Books
                .Select(book => new EagerBook(
                    book.Id,
                    book.AuthorId,
                    book.PublishingHouseId,
                    book.Title,
                    book.IsForAdults,
                    book.Author != null ? book.Author.Lastname : null,
                    book.PublishingHouse != null ? book.PublishingHouse.Name : null))
                .ToListAsync();
        }

        public static async Task<EagerBook[]> GetEagerArrayAllAdultBookUsingSelectAsync()
        {
            using var context = new LinqQueriesDBContext();

            return await context.Books
                .Select(book => new EagerBook(
                    book.Id,
                    book.AuthorId,
                    book.PublishingHouseId,
                    book.Title,
                    book.IsForAdults,
                    book.Author != null ? book.Author.Lastname : null,
                    book.PublishingHouse != null ? book.PublishingHouse.Name : null))
                .ToArrayAsync();
        }

        public static async Task<IEnumerable<EagerBook>> GetEagerIEnumerableAllAdultBookUsingSelectAsync()
        {
            using var context = new LinqQueriesDBContext();

            return await context.Books
                .Select(book => new EagerBook(
                    book.Id,
                    book.AuthorId,
                    book.PublishingHouseId,
                    book.Title,
                    book.IsForAdults,
                    book.Author != null ? book.Author.Lastname : null,
                    book.PublishingHouse != null ? book.PublishingHouse.Name : null))
                .ToListAsync();
        }
    }
}
