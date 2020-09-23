namespace MyPet.Application.Identity.Commands.LoginCompany
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.Identity.Contracts;
    using MyPet.Domain.Common.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginCompanyCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginCompanyCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<Result<LoginOutputModel>> Handle(LoginCompanyCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.LoginCompany(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                return new LoginOutputModel(result.Data.UserId, result.Data.Token);
            }
        }

        public class LoginCompanyCommandValidator : AbstractValidator<LoginCompanyCommand>
        {
            public LoginCompanyCommandValidator()
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
            }
        }
    }
}
