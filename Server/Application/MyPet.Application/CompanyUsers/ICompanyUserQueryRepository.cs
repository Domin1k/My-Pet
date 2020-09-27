namespace MyPet.Application.CompanyUsers
{
    using MyPet.Application.Common.Contracts;
    using MyPet.Application.CompanyUsers.Queries.Profile;
    using MyPet.Domain.CompanyUsers.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICompanyUserQueryRepository : IQueryRepository<CompanyUser>
    {
        Task<CompanyUserProfileOutputModel> GetDetails(Guid appUserId, CancellationToken cancellationToken = default);
    }
}
