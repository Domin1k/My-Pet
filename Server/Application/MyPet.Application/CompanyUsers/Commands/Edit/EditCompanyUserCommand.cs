namespace MyPet.Application.CompanyUsers.Commands.Edit
{
    using MediatR;
    using MyPet.Application.Common;

    public class EditCompanyUserCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
