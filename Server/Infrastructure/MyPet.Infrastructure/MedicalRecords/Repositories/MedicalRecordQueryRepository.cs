namespace MyPet.Infrastructure.MedicalRecords.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.MedicalRecords;
    using MyPet.Application.MedicalRecords.Queries.Common;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Application.MedicalRecords.Queries.Search;
    using MyPet.Domain.Common;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Common;
    using MyPet.Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MedicalRecordQueryRepository : DataRepository<IMedicalRecordsDbContext, MedicalRecord>, IMedicalRecordQueryRepository
    {
        private readonly IMapper mapper;

        public MedicalRecordQueryRepository(IMedicalRecordsDbContext db, IMapper mapper)
            : base(db) => this.mapper = mapper;

        public async Task<MedicalRecordDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<MedicalRecordDetailsOutputModel>(this.All().Where(x => x.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<MedicalRecordSearchOutputModel>> GetMedicalRecords(
            Specification<MedicalRecord> specification,
            MedicalRecordSortOrder sort, 
            int skip, 
            int take, 
            CancellationToken cancellationToken = default)
        {
            var data = await this.mapper
                    .ProjectTo<MedicalRecordSearchOutputModel>(this.GetMedicalRecordsQuery(specification))
                    .ToListAsync(cancellationToken);

            return data.Skip(skip).Take(take); // Old SQL Server version forces me to execute paging on the client.
        }

        private IQueryable<MedicalRecord> GetMedicalRecordsQuery(Specification<MedicalRecord> specification)
            => this
                .Data
                .MedicalRecords
                .Where(specification);
    }
}
