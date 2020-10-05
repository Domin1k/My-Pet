namespace Statistics.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.Statistics.Models;
    using MyPet.Infrastructure;
    using System.Reflection;

    public class StatisticsDbContext : DbContext, IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
          : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<AdoptionAdView> AdoptionAdViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
