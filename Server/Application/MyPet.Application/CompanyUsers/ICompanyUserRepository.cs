namespace MyPet.Application.CompanyUsers
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.CompanyUsers.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICompanyUserRepository : IRepository<CompanyUser>
    {
        Task<CompanyUser> FindBy(string userId, CancellationToken cancellationToken = default);
    }
}
