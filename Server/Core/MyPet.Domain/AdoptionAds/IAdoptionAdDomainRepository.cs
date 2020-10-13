namespace MyPet.Domain.AdoptionAds
{
    using MyPet.Domain.AdoptionAds.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAdoptionAdDomainRepository : IDomainRepository<AdoptionAd>
    {
        Task<AdoptionAd> Find(int id, CancellationToken cancellationToken = default);

        Task<AdoptionCategory> GetAdoptionCategory(string categoryName, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
