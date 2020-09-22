namespace MyPet.Application.Identity.Contracts
{
    using MyPet.Application.Common;
    using MyPet.Application.Identity.Commands;
    using MyPet.Application.Identity.Commands.ChangePassword;
    using MyPet.Application.Identity.Commands.LoginCompany;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IApplicationUser>> RegisterCompany(UserInputModel userInput);

        Task<Result<LoginOutputModel>> LoginCompany(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
