using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        ILogger logger)
    {
        var mediatRAssemblies = new[]
            {
              Assembly.GetAssembly(typeof(AdvisorDetailsDTO)), 
            };

        services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(mediatRAssemblies);
            });



        services.AddAutoMapper(x =>
        {
            x.CreateMap<CreateAdvisorDTO, AdvisorAggregate>();
            x.CreateMap<UpdateAdvisorDTO, AdvisorAggregate>()
                    .ReverseMap();
            x.CreateMap< AdvisorAggregate, AdvisorDetailsDTO>();


        });

        logger.LogInformation("{Project} services registered", "Application");

        return services;
    }

}
