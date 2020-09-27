namespace MyPet.Application.CompanyUsers.Commands.Common
{
    using MyPet.Application.Common;
    using System;

    public abstract class CompanyUserInputModel : EntityCommand<Guid>
    {
        public string LegalityRegistrationNumber { get; set; }

        public string CompanyName { get; set; }

        public string OwnerName { get; set; }

        public string Address { get; set; }
    }
}
