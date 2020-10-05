namespace MyPet.Infrastructure.CompanyUsers.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyPet.Application.CompanyUsers;
    using MyPet.Application.CompanyUsers.Queries.Profile;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Infrastructure.Common;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CompanyUserQueryRepository : DataRepository<ICompanyUsersDbContext, CompanyUser>, ICompanyUserQueryRepository
    {
        private readonly IMapper mapper;

        public CompanyUserQueryRepository(ICompanyUsersDbContext db, IMapper mapper)
            : base(db) => this.mapper = mapper;

        public Task<CompanyUserProfileOutputModel> GetDetails(Guid appUserId, CancellationToken cancellationToken = default)
            => this.mapper
                .ProjectTo<CompanyUserProfileOutputModel>(this.All().Where(x => x.ApplicationUserId == appUserId))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
