namespace MyPet.Infrastructure.AdoptionAds.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.AdoptionAds.Models;

    internal class AdoptionAdConfiguration : IEntityTypeConfiguration<AdoptionAd>
    {
        public void Configure(EntityTypeBuilder<AdoptionAd> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(AdoptionConstants.AdoptionAd.MaxAdoptionAdTitleLength);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(AdoptionConstants.AdoptionAd.MaxAdoptionAdDescriptionLength);

            builder
                .Property(x => x.PublisherId)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithOne()
                .HasForeignKey<AdoptionAd>("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
