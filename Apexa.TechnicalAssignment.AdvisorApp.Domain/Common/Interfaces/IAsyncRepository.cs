namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Interfaces;

public interface IAsyncRepository<T> where T : class
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);

}
