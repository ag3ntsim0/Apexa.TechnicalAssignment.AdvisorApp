using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Persistence;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Common.Repositories;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Persistence.Repositories;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Interfaces;
using Microsoft.Extensions.Options;


namespace Apexa.TechnicalAssignment.AdvisorApp.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
          this IServiceCollection services,
          ILogger logger)
        {
            

            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    //options.EnableSensitiveDataLogging();
                    options.UseInMemoryDatabase("Apexa.TechnicalAssignment.AdvisorAppDB");
                }

             );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAdvisorRepository, AdvisorRepository>();

            logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }
    }
}
