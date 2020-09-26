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

    internal class AdoptionAdRepository : DataRepository<IAdoptionAdsDbContext, AdoptionAd>, IAdoptionAdRepository
    {
        private readonly IMapper mapper;
        public AdoptionAdRepository(IAdoptionAdsDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await this.Find(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            this.Data.AdoptionAds.Remove(entity);
            await this.Data.SaveChangesAsync(cancellationToken);
            return true;
        }

        public Task<AdoptionAd> Find(int id, CancellationToken cancellationToken = default)
            => this.All()
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public Task<AdoptionCategory> GetAdoptionCategory(string categoryName, CancellationToken cancellationToken = default)
            => this.Data
                .AdoptionCategories
                .FirstOrDefaultAsync(x => x.Name.ToLower() == categoryName.ToLower(), cancellationToken);

        public Task<AdoptionAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => this.mapper
                .ProjectTo<AdoptionAdDetailsOutputModel>(this.All().Where(x => x.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
