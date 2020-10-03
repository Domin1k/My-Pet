namespace MyPet.Application.CompanyUsers.Commands.Create
{
    using System;

    public class CreateCompanyUserOutputModel
    {
        public CreateCompanyUserOutputModel(Guid userId) 
            => UserId = userId;

        public Guid UserId { get; }
    }
}
