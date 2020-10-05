namespace MyPet.Infrastructure.MedicalRecords
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Common;

    internal interface IMedicalRecordsDbContext : IDbContext
    {
        DbSet<MedicalRecord> MedicalRecords { get; }

        DbSet<Treatment> Treatments { get; }
    }
}
