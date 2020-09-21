namespace MyPet.Application.MedicalRecords
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.MedicalRecords.Models;

    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
        
    }
}
