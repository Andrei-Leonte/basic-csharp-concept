using LinqQueries.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace LinqQueriesConsole.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly LinqQueriesDBContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            context = new LinqQueriesDBContext();
            dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAsync(IQueryable<TEntity> queryable)
        {
            return await queryable.ToListAsync();
        }

        public async virtual Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
