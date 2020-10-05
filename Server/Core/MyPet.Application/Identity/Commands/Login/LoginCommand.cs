namespace MyPet.Application.Identity.Commands.Login
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.Identity.Contracts;
    using MyPet.Domain.Common.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginCommandHandler(IIdentity identity) => this.identity = identity;

            public async Task<Result<LoginOutputModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                return new LoginOutputModel(result.Data.UserId, result.Data.Token);
            }
        }

        public class LoginCommandValidator : AbstractValidator<LoginCommand>
        {
            public LoginCommandValidator()
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
