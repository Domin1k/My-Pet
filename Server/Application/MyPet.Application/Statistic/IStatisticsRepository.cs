namespace MyPet.Application.Statistic
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.Statistics.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStatisticsRepository : IRepository<Statistics>
    {
        Task<int> GetAdoptionAdsView(int adoptionAdId, CancellationToken cancellationToken = default);

        Task IncrementAdoptionAds(CancellationToken cancellationToken = default);
    }
}
