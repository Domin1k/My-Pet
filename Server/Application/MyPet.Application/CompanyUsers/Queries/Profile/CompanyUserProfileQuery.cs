namespace MyPet.Application.CompanyUsers.Queries.Profile
{
    using MediatR;
    using MyPet.Application.Common;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CompanyUserProfileQuery : EntityCommand<Guid>, IRequest<CompanyUserProfileOutputModel>
    {
        public class CompanyUserProfileQueryHandler : IRequestHandler<CompanyUserProfileQuery, CompanyUserProfileOutputModel>
        {
            private readonly ICompanyUserQueryRepository companyUserRepository;

            public CompanyUserProfileQueryHandler(ICompanyUserQueryRepository companyUserRepository) 
                => this.companyUserRepository = companyUserRepository;

            public Task<CompanyUserProfileOutputModel> Handle(CompanyUserProfileQuery request, CancellationToken cancellationToken)
                => this.companyUserRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
