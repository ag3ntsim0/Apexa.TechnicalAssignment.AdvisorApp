namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Common.Interfaces;

public interface IAsyncRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

}
