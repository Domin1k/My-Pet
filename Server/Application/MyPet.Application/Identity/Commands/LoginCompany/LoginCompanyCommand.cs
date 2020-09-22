namespace MyPet.Application.Identity.Commands.LoginCompany
{
    using MediatR;
    using MyPet.Application.Common;

    public class LoginCompanyCommand : UserInputModel, IRequest<Result>
    {
        
    }
}
