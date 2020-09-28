namespace MyPet.Application.CompanyUsers.Commands.Edit
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditCompanyUserCommand : EntityCommand<int>, IRequest<Result>
    {
        public string LegalityRegistrationNumber { get; set; }

        public string CompanyName { get; set; }

        public string OwnerName { get; set; }

        public string Address { get; set; }

        public class EditCompanyUserCommandHandler : IRequestHandler<EditCompanyUserCommand, Result>
        {
            private readonly ICompanyUserDomainRepository companyUserRepository;
            private readonly ICurrentUserService currentUserService;

            public EditCompanyUserCommandHandler(ICompanyUserDomainRepository companyUserRepository, ICurrentUserService currentUserService)
            {
                this.companyUserRepository = companyUserRepository;
                this.currentUserService = currentUserService;
            }

            public async Task<Result> Handle(EditCompanyUserCommand request, CancellationToken cancellationToken)
            {
                var companyUser = await this.companyUserRepository.FindBy(this.currentUserService.UserId);
                companyUser
                    .UpdateAddress(request.Address)
                    .UpdateCompanyName(request.CompanyName)
                    .UpdateLegalityRegistrationNumber(request.LegalityRegistrationNumber)
                    .UpdateOwnerName(request.OwnerName);

                await this.companyUserRepository.Save(companyUser, cancellationToken);

                return Result.Success;
            }
        }

        public class CompanyUserCommandValidator : AbstractValidator<EditCompanyUserCommand>
        {
            public CompanyUserCommandValidator()
            {
                this.RuleFor(x => x.Address)
                    .MinimumLength(CompanyUsersConstants.CompanyUser.MinAddressLength)
                    .MaximumLength(CompanyUsersConstants.CompanyUser.MaxAddressLength)
                    .NotEmpty();

                this.RuleFor(x => x.CompanyName)
                    .MinimumLength(ModelConstants.Common.MinNameLength)
                    .MaximumLength(ModelConstants.Common.MaxNameLength)
                    .NotEmpty();

                this.RuleFor(x => x.OwnerName)
                    .MinimumLength(CompanyUsersConstants.CompanyUser.MinOwnerName)
                    .MaximumLength(CompanyUsersConstants.CompanyUser.MaxOwnerName)
                    .NotEmpty();

                this.RuleFor(x => x.LegalityRegistrationNumber)
                    .MinimumLength(CompanyUsersConstants.CompanyUser.MinLegalityRegistrationNumberLength)
                    .MaximumLength(CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength)
                    .NotEmpty();
            }
        }
    }
}
