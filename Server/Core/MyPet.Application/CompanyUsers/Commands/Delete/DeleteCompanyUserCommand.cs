namespace MyPet.Application.CompanyUsers.Commands.Delete
{
    using MediatR;
    using MyPet.Domain.CompanyUsers;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;

    public class DeleteCompanyUserCommand : IRequest<Result>
    {
        public class DeleteCompanyUserCommandHandler : IRequestHandler<DeleteCompanyUserCommand, Result>
        {
            private readonly ICompanyUserDomainRepository companyUserRepository;
            private readonly ICurrentUserService currentUserService;

            public DeleteCompanyUserCommandHandler(ICompanyUserDomainRepository companyUserRepository, ICurrentUserService currentUserService)
            {
                this.companyUserRepository = companyUserRepository;
                this.currentUserService = currentUserService;
            }

            public async Task<Result> Handle(DeleteCompanyUserCommand request, CancellationToken cancellationToken)
                => await this.companyUserRepository.Delete(this.currentUserService.UserId, cancellationToken);
        }
    }
}
