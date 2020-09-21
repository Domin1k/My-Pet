namespace MyPet.Infrastructure.MedicalRecords.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Models;

    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.AnimalAge)
                .IsRequired()
                .HasMaxLength(MedicalRecordConstants.MedicalRecord.MaxAge);

            builder
                .Property(x => x.AnimalName)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
                .Property(x => x.AnimalBreed)
                .IsRequired()
                .HasMaxLength(MedicalRecordConstants.MedicalRecord.MaxBreedLength);
        }
    }
}
