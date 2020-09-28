namespace MyPet.Infrastructure.Identity
{
    using Application.Common;
    using Microsoft.AspNetCore.Identity;
    using MyPet.Application.Identity.Commands;
    using MyPet.Application.Identity.Commands.Login;
    using MyPet.Application.Identity.Contracts;
    using System.Linq;
    using System.Threading.Tasks;

    internal class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<IApplicationUser>> Register(UserInputModel userInput)
        {
            var user = new ApplicationUser(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IApplicationUser>.SuccessWith(user)
                : Result<IApplicationUser>.Failure(errors);
        }

        public async Task<Result<LoginOutputModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new LoginOutputModel(user.Id, token);
        }
    }
}
