namespace MyPet.Application.CompanyUsers.Queries.Profile
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;

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
