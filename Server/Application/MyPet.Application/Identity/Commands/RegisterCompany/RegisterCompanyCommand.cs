namespace MyPet.Application.Identity.Commands.RegisterCompany
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.CompanyUsers;
    using MyPet.Application.Identity.Contracts;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Factories;
    using MyPet.Domain.CompanyUsers.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterCompanyCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string OwnerName { get; set; }

        public string LegalityRegistrationNumber { get; set; }

        public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly ICompanyUserFactory companyUserFactory;
            private readonly ICompanyUserRepository companyUsersRepository;

            public RegisterCompanyCommandHandler(
                IIdentity identity,
                ICompanyUserFactory companyUserFactory,
                ICompanyUserRepository companyUsersRepository)
            {
                this.identity = identity;
                this.companyUserFactory = companyUserFactory;
                this.companyUsersRepository = companyUsersRepository;
            }

            public async Task<Result> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.RegisterCompany(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var companyUser = this.companyUserFactory
                            .WithApplicationUserId(result.Data.Id)
                            .WithLegalityRegistrationNumber(request.LegalityRegistrationNumber)
                            .WithName(request.Name)
                            .WithOwnerName(request.OwnerName)
                            .WithAddress(request.Address)
                            .Build();

                await this.companyUsersRepository.Save(companyUser, cancellationToken);
                
                return result;
            }
        }

        public class RegisterCompanyCommandValidator : AbstractValidator<RegisterCompanyCommand>
        {
            public RegisterCompanyCommandValidator()
            {
                this.RuleFor(u => u.Email)
                   .MinimumLength(ModelConstants.Common.MinEmailLength)
                   .MaximumLength(ModelConstants.Common.MaxEmailLength)
                   .EmailAddress()
                   .NotEmpty();

                this.RuleFor(u => u.Password)
                    .MinimumLength(ModelConstants.Common.MinNameLength)
                    .MaximumLength(ModelConstants.Common.MaxNameLength)
                    .NotEmpty();

                this.RuleFor(u => u.Name)
                    .MinimumLength(ModelConstants.Common.MinNameLength)
                    .MaximumLength(ModelConstants.Common.MaxNameLength)
                    .NotEmpty();

                this.RuleFor(u => u.Address)
                    .MinimumLength(CompanyUsersConstants.CompanyUser.MinAddressLength)
                    .MaximumLength(CompanyUsersConstants.CompanyUser.MaxAddressLength)
                    .NotEmpty();

                this.RuleFor(u => u.LegalityRegistrationNumber)
                    .MinimumLength(CompanyUsersConstants.CompanyUser.MinLegalityRegistrationNumberLength)
                    .MaximumLength(CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength)
                    .NotEmpty();
            }
        }
    }
}
