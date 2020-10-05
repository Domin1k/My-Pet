namespace MyPet.Infrastructure.Statistic.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyPet.Domain.Statistics.Models;

    internal class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            const string id = "Id";

            builder
                .Property<int>(id);

            builder
                .HasKey(id);

            builder
                .HasMany(d => d.AdoptionAdViews)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("adoptionAdViews");
        }
    }
}
