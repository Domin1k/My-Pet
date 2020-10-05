namespace MyPet.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.Statistics.Models;
    using MyPet.Infrastructure.Common;

    internal interface IStatisticsDbContext : IDbContext
    {
        DbSet<AdoptionAdView> AdoptionAdViews { get; }

        DbSet<Statistics> Statistics { get; }
    }
}
