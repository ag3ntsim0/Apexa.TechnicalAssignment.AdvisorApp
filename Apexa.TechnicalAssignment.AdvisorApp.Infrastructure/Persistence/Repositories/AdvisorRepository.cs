using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Common.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Persistence.Repositories
{
    public class AdvisorRepository : BaseRepository<AdvisorAggregate>, IAdvisorRepository
    {

        public AdvisorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<AdvisorAggregate> GetByIdAsync(Guid id)
        {
            return await _dbContext.Advisors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(item => item.ID == id);
        }

        public async Task<AdvisorAggregate> GetBySINAsync(string SIN)
        {
            return await _dbContext.Advisors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(item => item.SIN == SIN);
        }
        public async Task<List<AdvisorAggregate>> GetAdvisorsAsync(int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Advisors.AsQueryable();
            var totalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
            var advisors = await query
                           .Skip((pageIndex - 1) * pageSize)
                           .Take(pageSize).ToListAsync();

            return advisors;
        }
    }
}
