using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Apexa.TechnicalAssignment.AdvisorApp.Infrastructure.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            
        }



        public DbSet<AdvisorAggregate> Advisors => Set<AdvisorAggregate>();


        


        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();

    }
}
