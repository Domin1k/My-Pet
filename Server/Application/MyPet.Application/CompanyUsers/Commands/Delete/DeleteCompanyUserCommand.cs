namespace MyPet.Application.CompanyUsers.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Domain.CompanyUsers;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCompanyUserCommand : EntityCommand<Guid>, IRequest<Result>
    {
        public class DeleteCompanyUserCommandHandler : IRequestHandler<DeleteCompanyUserCommand, Result>
        {
            private readonly ICompanyUserDomainRepository companyUserRepository;

            public DeleteCompanyUserCommandHandler(ICompanyUserDomainRepository companyUserRepository)
                => this.companyUserRepository = companyUserRepository;

            public async Task<Result> Handle(DeleteCompanyUserCommand request, CancellationToken cancellationToken)
                => await this.companyUserRepository.Delete(request.Id, cancellationToken);
        }
    }
}
