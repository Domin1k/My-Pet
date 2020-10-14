namespace MyPet.Application.CompanyUsers.Commands.Edit
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.CompanyUsers.Commands.Common;
    using MyPet.Domain.CompanyUsers;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models;

    public class EditCompanyUserCommand : CompanyUserInputModel, IRequest<Result>
    {
        public string CompanyEmailAddress { get; set; }

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
                    .UpdateCompanyEmail(request.CompanyEmailAddress)
                    .UpdateLegalityRegistrationNumber(request.LegalityRegistrationNumber)
                    .UpdateOwnerName(request.OwnerName);

                await this.companyUserRepository.Save(companyUser, cancellationToken);

                return Result.Success;
            }
        }

        public class EditCompanyUserCommandValidator : CompanyUserCommandValidator<EditCompanyUserCommand>
        {
            public EditCompanyUserCommandValidator()
                : base()
            {
                this.RuleFor(x => x.CompanyEmailAddress)
                    .EmailAddress()
                    .MinimumLength(ModelConstants.Common.MinEmailLength)
                    .MaximumLength(ModelConstants.Common.MaxEmailLength)
                    .NotEmpty();
            }
        }
    }
}
