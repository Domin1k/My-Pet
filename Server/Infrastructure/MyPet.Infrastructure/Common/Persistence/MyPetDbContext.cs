namespace MyPet.Infrastructure.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Identity;
    using System.Reflection;

    internal class MyPetDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyPetDbContext(DbContextOptions<MyPetDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public DbSet<AdoptionAd> AdoptionAds { get; set; }

        public DbSet<AdoptionCategory> AdoptionCategories { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
