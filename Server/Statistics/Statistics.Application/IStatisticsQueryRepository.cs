namespace MyPet.Application.Statistic
{
    using MyPet.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;

    public interface IStatisticsQueryRepository : IQueryRepository<Statistics>
    {
        Task<int> GetAdoptionAdsView(int adoptionAdId, CancellationToken cancellationToken = default);

        Task IncrementAdoptionAds(CancellationToken cancellationToken = default);
    }
}
