namespace MyPet.Application.Identity.Contracts
{
    using MyPet.Application.Identity.Commands;
    using MyPet.Application.Identity.Commands.Login;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IApplicationUser>> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
