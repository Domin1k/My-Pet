namespace MyPet.Infrastructure.CompanyUsers.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CompanyUserRepository : DataRepository<ICompanyUsersDbContext, CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(ICompanyUsersDbContext db) 
            : base(db)
        {
        }

        public Task<CompanyUser> FindBy(string userId, CancellationToken cancellationToken = default)
            => this.All().FirstOrDefaultAsync(x => x.ApplicationUserId == userId, cancellationToken);
    }
}
