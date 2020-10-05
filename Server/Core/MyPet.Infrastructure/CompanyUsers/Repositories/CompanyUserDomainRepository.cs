namespace MyPet.Infrastructure.CompanyUsers.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CompanyUserDomainRepository : DataRepository<ICompanyUsersDbContext, CompanyUser>, ICompanyUserDomainRepository
    {
        public CompanyUserDomainRepository(ICompanyUsersDbContext db) 
            : base(db)
        {
        }

        public async Task<bool> Delete(Guid appUserId, CancellationToken cancellationToken = default)
        {
            var entity = await this.FindBy(appUserId, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            this.Data.CompanyUsers.Remove(entity);

            await this.Data.SaveChangesAsync();
            return true;
        }

        public Task<CompanyUser> FindBy(Guid appUserId, CancellationToken cancellationToken = default)
            => this
                .All()
                .FirstOrDefaultAsync(x => x.ApplicationUserId == appUserId, cancellationToken);
    }
}
