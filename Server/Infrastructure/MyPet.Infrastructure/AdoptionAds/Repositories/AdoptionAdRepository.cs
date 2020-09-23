namespace MyPet.Infrastructure.AdoptionAds.Repositories
{
    using MyPet.Application.AdoptionAds;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Infrastructure.Common.Persistence;

    internal class AdoptionAdRepository : DataRepository<IAdoptionAdsDbContext, AdoptionAd>, IAdoptionAdRepository
    {
        public AdoptionAdRepository(IAdoptionAdsDbContext db) 
            : base(db)
        {
        }
    }
}
