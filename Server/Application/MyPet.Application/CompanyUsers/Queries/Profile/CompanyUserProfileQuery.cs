namespace MyPet.Application.CompanyUsers.Queries.Profile
{
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.Common.Contracts;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CompanyUserProfileQuery : IRequest<CompanyUserProfileOutputModel>
    {
        public class CompanyUserProfileQueryHandler : IRequestHandler<CompanyUserProfileQuery, CompanyUserProfileOutputModel>
        {
            private readonly ICompanyUserQueryRepository companyUserRepository;
            private readonly ICurrentUserService currentUserService;

            public CompanyUserProfileQueryHandler(ICompanyUserQueryRepository companyUserRepository, ICurrentUserService currentUserService)
            {
                this.companyUserRepository = companyUserRepository;
                this.currentUserService = currentUserService;
            }

            public Task<CompanyUserProfileOutputModel> Handle(CompanyUserProfileQuery request, CancellationToken cancellationToken)
                => this.companyUserRepository.GetDetails(this.currentUserService.UserId, cancellationToken);
        }
    }
}
