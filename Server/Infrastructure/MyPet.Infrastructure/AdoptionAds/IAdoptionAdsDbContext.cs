namespace MyPet.Infrastructure.AdoptionAds
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Infrastructure.Common.Persistence;

    internal interface IAdoptionAdsDbContext : IDbContext
    {
        DbSet<AdoptionAd> AdoptionAds { get; }

        DbSet<AdoptionCategory> AdoptionCategories { get; }
    }
}
