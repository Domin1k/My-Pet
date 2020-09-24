namespace MyPet.Infrastructure.MedicalRecords.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.MedicalRecords;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Common.Persistence;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MedicalRecordRepository : DataRepository<IMedicalRecordsDbContext, MedicalRecord>, IMedicalRecordRepository
    {
        private readonly IMapper mapper;
        public MedicalRecordRepository(IMedicalRecordsDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public Task<MedicalRecord> Find(int id, CancellationToken cancellationToken = default)
            => this.All()
                .Include(x => x.Treatments)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<MedicalRecordDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<MedicalRecordDetailsOutputModel>(this.All().Where(x => x.Id == id))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
