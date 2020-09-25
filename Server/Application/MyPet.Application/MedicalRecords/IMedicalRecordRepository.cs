namespace MyPet.Application.MedicalRecords
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
        Task<MedicalRecordDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<MedicalRecord> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
