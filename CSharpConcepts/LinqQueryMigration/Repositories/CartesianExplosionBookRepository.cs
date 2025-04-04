using LinqQueries.DbContexts;
using LinqQueriesConsole.PartialEntities;
using Microsoft.EntityFrameworkCore;

namespace LinqQueriesConsole.Repositories
{
    public class CartesianExplosionBookRepository() : BaseRepository<Book>()
    {
        public static async Task<List<Book>> GetEagerAllAdultBookWithCartesianExplosionAsync()
        {
            using var context = new LinqQueriesDBContext();

            return await context.Books
                .Include(book => book.Author)
                .Include(book => book.PublishingHouse)
                .Where(book => book.IsForAdults)
                .ToListAsync();
        }

        public static async Task<List<EagerBook>> GetEagerAllAdultBookUsingSelectAsync()
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