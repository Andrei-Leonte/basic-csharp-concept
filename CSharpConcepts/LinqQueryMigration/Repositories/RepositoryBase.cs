using Microsoft.EntityFrameworkCore;

namespace LinqQueriesConsole.Repositories
{
    public class RepositoryBase<TEntity> where TEntity : class
    {
        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> queryable)
        {
            return await queryable.ToListAsync();
        }
    }
}
