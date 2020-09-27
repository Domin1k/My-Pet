namespace MyPet.Infrastructure.Statistic.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Statistics.Models;
    using MyPet.Infrastructure.Identity;

    internal class AdoptionAdViewConfiguration : IEntityTypeConfiguration<AdoptionAdView>
    {
        public void Configure(EntityTypeBuilder<AdoptionAdView> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<AdoptionAdView>()
                .WithMany()
                .HasForeignKey(x => x.AdoptionAdId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
