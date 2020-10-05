namespace MyPet.Infrastructure.AdoptionAds.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.AdoptionAds;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Infrastructure.Common;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AdoptionAdDomainRepository : DataRepository<IAdoptionAdsDbContext, AdoptionAd>, IAdoptionAdDomainRepository
    {
        public AdoptionAdDomainRepository(IAdoptionAdsDbContext db) 
            : base(db)
        {
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
    }
}
