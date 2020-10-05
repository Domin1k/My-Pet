namespace Statistics.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Infrastructure;
    using Statistics.Infrastructure.Persistence;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddStatisticsInfrastructure(this IServiceCollection services)
            => services
                .AddScoped<IStatisticsDbContext>(provider => provider.GetService<StatisticsDbContext>());
    }
}
