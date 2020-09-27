namespace MyPet.Application.AdoptionAds
{
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.AdoptionAds.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAdoptionAdQueryRepository : IQueryRepository<AdoptionAd>
    {
        Task<AdoptionAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);
    }
}
