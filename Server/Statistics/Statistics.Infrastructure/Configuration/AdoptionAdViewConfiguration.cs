namespace MyPet.Infrastructure.Statistic.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Statistics.Models;

    internal class AdoptionAdViewConfiguration : IEntityTypeConfiguration<AdoptionAdView>
    {
        public void Configure(EntityTypeBuilder<AdoptionAdView> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .HasOne<AdoptionAdView>()
                .WithMany()
                .HasForeignKey(x => x.AdoptionAdId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
