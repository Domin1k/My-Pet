namespace MyPet.Application.AdoptionAds
{
    using MyPet.Application.AdoptionAds.Queries.Common;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.AdoptionAds.Queries.Search;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAdoptionAdQueryRepository : IQueryRepository<AdoptionAd>
    {
        Task<AdoptionAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AdoptionAdSearchOutputModel>> GetAdoptionAds(
            Specification<AdoptionAd> specification,
            AdoptionAdSortOrder sort,
            int skip,
            int take,
            CancellationToken cancellationToken = default);
    }
}
