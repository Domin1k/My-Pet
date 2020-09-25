namespace MyPet.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.Statistics.Models;
    using MyPet.Infrastructure.Common.Persistence;

    public interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }
    }
}
