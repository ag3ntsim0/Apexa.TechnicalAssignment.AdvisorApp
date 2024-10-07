using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Common.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
