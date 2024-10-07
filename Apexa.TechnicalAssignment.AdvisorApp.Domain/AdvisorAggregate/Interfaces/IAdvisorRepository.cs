using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Interfaces;

namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;

public interface IAdvisorRepository : IAsyncRepository<AdvisorAggregate>
{

    Task<AdvisorAggregate> GetByIdAsync(Guid id);

    Task<AdvisorAggregate> GetBySINAsync(string sin);

    Task<List<AdvisorAggregate>> GetAdvisorsAsync(int pageIndex=1, int pageSize = 10);
}
