namespace MyPet.Infrastructure.CompanyUsers
{
    using Microsoft.EntityFrameworkCore;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common.Persistence;
    using MyPet.Infrastructure.Identity;

    public interface ICompanyUsersDbContext : IDbContext
    {
        DbSet<CompanyUser> CompanyUsers { get; }
    }
}
