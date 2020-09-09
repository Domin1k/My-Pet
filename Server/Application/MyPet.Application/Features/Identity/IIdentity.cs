namespace MyPet.Application.Features.Identity
{
    using MyPet.Application.Common;
    using MyPet.Application.Features.Identity.Commands;
    using MyPet.Application.Features.Identity.Commands.ChangePassword;
    using MyPet.Application.Features.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
