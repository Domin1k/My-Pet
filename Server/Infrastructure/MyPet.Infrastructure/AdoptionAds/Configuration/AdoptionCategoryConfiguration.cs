namespace MyPet.Infrastructure.AdoptionAds.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.AdoptionAds.Models;

    public class AdoptionCategoryConfiguration : IEntityTypeConfiguration<AdoptionCategory>
    {
        public void Configure(EntityTypeBuilder<AdoptionCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(AdoptionConstants.AdoptionCategory.MaxAdoptionCategoryNameLength);
        }
    }
}
