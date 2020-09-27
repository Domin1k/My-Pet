namespace MyPet.Application.CompanyUsers.Commands.Create
{
    using MediatR;
    using MyPet.Application.CompanyUsers.Commands.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCompanyUserCommand : CompanyUserInputModel, IRequest<CreateCompanyUserOutputModel>
    {
        public class CreateCompanyUserCommandHandler : IRequestHandler<CreateCompanyUserCommand, CreateCompanyUserOutputModel>
        {
            public Task<CreateCompanyUserOutputModel> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
