namespace MyPet.Infrastructure.AdoptionAds.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.AdoptionAds;
    using MyPet.Application.AdoptionAds.Queries.Common;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.AdoptionAds.Queries.Search;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common;
    using MyPet.Infrastructure.Common;
    using MyPet.Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AdoptionAdQueryRepository : DataRepository<IAdoptionAdsDbContext, AdoptionAd>, IAdoptionAdQueryRepository
    {
        private readonly IMapper mapper;

        public AdoptionAdQueryRepository(IAdoptionAdsDbContext db, IMapper mapper)
            : base(db) => this.mapper = mapper;

        public Task<AdoptionAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => this.mapper
                .ProjectTo<AdoptionAdDetailsOutputModel>(this.All().Where(x => x.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<AdoptionAdSearchOutputModel>> GetAdoptionAds(
            Specification<AdoptionAd> specification,
            AdoptionAdSortOrder sort,
            int skip, 
            int take, 
            CancellationToken cancellationToken = default)
        {
            var data = await this.mapper
                   .ProjectTo<AdoptionAdSearchOutputModel>(this.All().Where(specification).Sort(sort))
                   .ToListAsync(cancellationToken);

            return data.Skip(skip).Take(take); // EF Core bug forces me to execute paging on the client.
        }
    }
}
