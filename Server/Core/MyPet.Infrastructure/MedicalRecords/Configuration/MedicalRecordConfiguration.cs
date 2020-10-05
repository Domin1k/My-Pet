namespace MyPet.Infrastructure.MedicalRecords.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Models;

    internal class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseHiLo();

            builder
                .Property(x => x.AnimalAge)
                .IsRequired()
                .HasMaxLength(MedicalRecordConstants.MedicalRecord.MaxAge);

            builder
                .Property(x => x.AnimalName)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
               .OwnsOne(c => c.AnimalBreed, o =>
               {
                   o.WithOwner();

                   o.Property(op => op.BreedName);

                   o.OwnsOne(
                       op => op.Species,
                       t =>
                       {
                           t.WithOwner();

                           t.Property(tr => tr.Value);
                       });
               });
        }
    }
}
