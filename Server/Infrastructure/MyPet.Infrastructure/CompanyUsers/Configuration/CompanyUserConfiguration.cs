namespace MyPet.Infrastructure.CompanyUsers.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Models;

    public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
        {
            builder
               .HasKey(d => d.Id);

            builder
                .Property(d => d.CompanyName)
                .IsRequired()
                .HasMaxLength(ModelConstants.Common.MaxNameLength);

            builder
                .Property(d => d.OwnerName)
                .IsRequired()
                .HasMaxLength(CompanyUsersConstants.CompanyUser.MaxOwnerName);

            builder
                .Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(CompanyUsersConstants.CompanyUser.MaxAddressLength);

            builder
                .Property(d => d.LegalityRegistrationNumber)
                .IsRequired()
                .HasMaxLength(CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength);

            builder
                .HasMany(d => d.MedicalRecords)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("medicalRecords");
        }
    }
}
