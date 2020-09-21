namespace MyPet.Application.Identity.Contracts
{
    using MyPet.Application.Common;
    using MyPet.Application.Identity.Commands;
    using MyPet.Application.Identity.Commands.ChangePassword;
    using MyPet.Application.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
