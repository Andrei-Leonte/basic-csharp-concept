using LinqQueries.DbContexts;

namespace LinqQueriesConsole.Repositories
{
    public class BookRepository() : BaseRepository<Book>()
    {
        public async Task<List<Book>> GetAdultBooksAsync()
        {
            var query = dbSet.Where(b => b.IsForAdults);

            return await GetAsync(query);
        }

        public async Task<List<Book>> GetBooksByAuthorAsync(int authorId)
        {
            var query = dbSet.Where(b => b.AuthorId == authorId);

            return await GetAsync(query);
        }

        public async Task<List<Book>> GetBooksByPublishingHouseAsync(int publishingHouseId)
        {
            var query = dbSet.Where(b => b.PublishingHouseId == publishingHouseId);

            return await GetAsync(query);
        }
    }
}