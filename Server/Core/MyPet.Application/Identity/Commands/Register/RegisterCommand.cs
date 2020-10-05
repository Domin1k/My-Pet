namespace MyPet.Application.Identity.Commands.Register
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.Identity.Contracts;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers;
    using MyPet.Domain.CompanyUsers.Factories;
    using MyPet.Domain.CompanyUsers.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string OwnerName { get; set; }

        public string LegalityRegistrationNumber { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly ICompanyUserFactory companyUserFactory;
            private readonly ICompanyUserDomainRepository companyUsersRepository;

            public RegisterCommandHandler(
                IIdentity identity,
                ICompanyUserFactory companyUserFactory,
                ICompanyUserDomainRepository companyUsersRepository)
            {
                this.identity = identity;
                this.companyUserFactory = companyUserFactory;
                this.companyUsersRepository = companyUsersRepository;
            }

            public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var companyUser = this.companyUserFactory
                            .WithApplicationUserId(new Guid(result.Data.Id))
                            .WithLegalityRegistrationNumber(request.LegalityRegistrationNumber)
                            .WithCompanyName(request.Name)
                            .WithOwnerName(request.OwnerName)
                            .WithAddress(request.Address)
                            .Build();

                await this.companyUsersRepository.Save(companyUser, cancellationToken);
                
                return result;
            }
        }

        public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
        {
            public RegisterCommandValidator()
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
