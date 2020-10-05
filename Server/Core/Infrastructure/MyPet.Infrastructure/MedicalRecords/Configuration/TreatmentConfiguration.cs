namespace MyPet.Infrastructure.MedicalRecords.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Models;

    internal class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(MedicalRecordConstants.Treatment.MaxTreatmentTitleLength);

            builder
                 .Property(x => x.ImageUrl)
                 .IsRequired()
                 .HasMaxLength(ModelConstants.Common.MaxUrlLength);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(MedicalRecordConstants.Treatment.MaxTreatmentDescriptionLength);
        }
    }
}
