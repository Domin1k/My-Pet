namespace MyPet.Application.MedicalRecords
{
    using MyPet.Application.MedicalRecords.Queries.Common;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Application.MedicalRecords.Queries.Search;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain;

    public interface IMedicalRecordQueryRepository : IQueryRepository<MedicalRecord>
    {
        Task<MedicalRecordDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<MedicalRecordSearchOutputModel>> GetMedicalRecords(
            Specification<MedicalRecord> specification,
            MedicalRecordSortOrder medicalRecordSortOrder,
            int skip,
            int take,
            CancellationToken cancellationToken = default);
    }
}
