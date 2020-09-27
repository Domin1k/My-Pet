namespace MyPet.Infrastructure.AdoptionAds.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.AdoptionAds;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Infrastructure.Common.Persistence;
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
    }
}
