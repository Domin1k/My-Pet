namespace MyPet.Infrastructure.CompanyUsers
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common;

    internal interface ICompanyUsersDbContext : IDbContext
    {
        DbSet<CompanyUser> CompanyUsers { get; }
    }
}
