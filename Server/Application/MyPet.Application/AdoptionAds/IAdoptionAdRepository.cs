namespace MyPet.Application.AdoptionAds
{
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.AdoptionAds.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAdoptionAdRepository : IRepository<AdoptionAd>
    {
        Task<AdoptionAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<AdoptionAd> Find(int id, CancellationToken cancellationToken = default);

        Task<AdoptionCategory> GetAdoptionCategory(string categoryName, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
