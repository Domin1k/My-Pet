namespace MyPet.Application.CompanyUsers.Commands.Edit
{
    using MediatR;
    using MyPet.Application.Common.Contracts;
    using MyPet.Application.CompanyUsers.Commands.Common;
    using MyPet.Application.CompanyUsers.Commands.Create;
    using MyPet.Domain.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Factories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCompanyUserCommand : CompanyUserInputModel, IRequest<CreateCompanyUserOutputModel>
    {
        public class CreateCompanyUserCommandHandler : IRequestHandler<CreateCompanyUserCommand, CreateCompanyUserOutputModel>
        {
            private readonly ICompanyUserDomainRepository companyUserRepository;
            private readonly ICurrentUserService currentUserService;
            private readonly ICompanyUserFactory companyUserFactory;

            public CreateCompanyUserCommandHandler(
                ICompanyUserDomainRepository companyUserRepository,
                ICurrentUserService currentUserService,
                ICompanyUserFactory companyUserFactory)
            {
                this.companyUserRepository = companyUserRepository;
                this.currentUserService = currentUserService;
                this.companyUserFactory = companyUserFactory;
            }

            public async Task<CreateCompanyUserOutputModel> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
            {
                var companyUser = this.companyUserFactory
                        .WithAddress(request.Address)
                        .WithApplicationUserId(this.currentUserService.UserId)
                        .WithCompanyEmail(this.currentUserService.Email)
                        .WithCompanyName(request.CompanyName)
                        .WithLegalityRegistrationNumber(request.LegalityRegistrationNumber)
                        .WithOwnerName(request.OwnerName)
                        .Build();

                await this.companyUserRepository.Save(companyUser, cancellationToken);

                return new CreateCompanyUserOutputModel(companyUser.ApplicationUserId);
            }
        }        
    }
}
