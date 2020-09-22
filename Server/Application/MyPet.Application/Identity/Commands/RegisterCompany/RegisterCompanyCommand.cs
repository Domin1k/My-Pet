namespace MyPet.Application.Identity.Commands.RegisterCompany
{
    using MediatR;
    using MyPet.Application.Common;

    public class RegisterCompanyCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string LegalityRegistrationNumber { get; set; }
    }
}
