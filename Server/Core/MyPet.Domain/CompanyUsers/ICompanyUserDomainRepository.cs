namespace MyPet.Domain.CompanyUsers
{
    using MyPet.Domain.Common;
    using MyPet.Domain.CompanyUsers.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICompanyUserDomainRepository : IDomainRepository<CompanyUser>
    {
        Task<CompanyUser> FindBy(Guid appUserId, CancellationToken cancellationToken = default);

        Task<bool> Delete(Guid appUserId, CancellationToken cancellationToken = default);
    }
}
