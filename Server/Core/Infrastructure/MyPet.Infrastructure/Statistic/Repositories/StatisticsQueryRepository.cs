namespace MyPet.Infrastructure.Statistic.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.Statistic;
    using MyPet.Domain.Statistics.Models;
    using MyPet.Infrastructure.Common;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsQueryRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsQueryRepository
    {
        public StatisticsQueryRepository(IStatisticsDbContext db) 
            : base(db)
        {
        }

        public async Task<int> GetAdoptionAdsView(int adoptionAdId, CancellationToken cancellationToken = default)
          => await this.Data
                .AdoptionAdViews
                .CountAsync(cav => cav.AdoptionAdId == adoptionAdId, cancellationToken);

        public async Task IncrementAdoptionAds(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
               .Statistics
               .SingleOrDefaultAsync(cancellationToken);

            statistics.AddAdoptionAd();

            await this.Save(statistics, cancellationToken);
        }
    }
}
