namespace MyPet.Infrastructure.CompanyUsers.Repositories
{
    using MyPet.Application.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common.Persistence;

    internal class CompanyUsersRepository : DataRepository<ICompanyUsersDbContext, CompanyUser>, ICompanyUsersRepository
    {
        public CompanyUsersRepository(ICompanyUsersDbContext db) 
            : base(db)
        {
        }
    }
}
