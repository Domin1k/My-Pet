namespace MyPet.Application.CompanyUsers.Commands.Common
{
    public abstract class CompanyUserInputModel
    {
        public string LegalityRegistrationNumber { get; set; }

        public string CompanyName { get; set; }

        public string OwnerName { get; set; }

        public string Address { get; set; }
    }
}
