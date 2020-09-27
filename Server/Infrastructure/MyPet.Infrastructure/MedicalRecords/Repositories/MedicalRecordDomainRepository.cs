namespace MyPet.Infrastructure.MedicalRecords.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.MedicalRecords;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MedicalRecordDomainRepository : DataRepository<IMedicalRecordsDbContext, MedicalRecord>, IMedicalRecordDomainRepository
    {
        public MedicalRecordDomainRepository(IMedicalRecordsDbContext db) 
            : base(db)
        {
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await this.Find(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            this.Data.MedicalRecords.Remove(entity);
            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public Task<MedicalRecord> Find(int id, CancellationToken cancellationToken = default)
            => this.All()
                .Include(x => x.Treatments)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
