namespace MyPet.Infrastructure.CompanyUsers.Repositories
{
    using MyPet.Application.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common.Persistence;

    internal class CompanyUserRepository : DataRepository<ICompanyUsersDbContext, CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(ICompanyUsersDbContext db) 
            : base(db)
        {
        }
    }
}
