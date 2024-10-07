
using Apexa.TechnicalAssignment.AdvisorApp.Presentation.Controllers;
using Apexa.TechnicalAssignment.AdvisorApp.Application;
using Apexa.TechnicalAssignment.AdvisorApp.Infrastructure;


namespace Apexa.TechnicalAssignment.AdvisorApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var presentationAssembly = typeof(AdvisorController).Assembly;
            builder.Services.AddControllers()
                .AddApplicationPart(presentationAssembly); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddLogging();

            var serviceProvider = builder.Services.BuildServiceProvider();

            // Get the logger factory and create a logger
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("StartupLogger");

            builder.Services.AddApplicationServices(logger);
            builder.Services.AddInfrastructureServices(logger);






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
