namespace MyPet.Domain.MedicalRecords
{
    using MyPet.Domain.Common;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMedicalRecordDomainRepository : IDomainRepository<MedicalRecord>
    {
        Task<MedicalRecord> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
