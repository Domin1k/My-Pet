namespace MyPet.Infrastructure.MedicalRecords.Repositories
{
    using MyPet.Application.MedicalRecords;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Common.Persistence;

    internal class MedicalRecordRepository : DataRepository<IMedicalRecordsDbContext, MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(IMedicalRecordsDbContext db)
            : base(db)
        {
        }
    }
}
