namespace MyPet.Application.CompanyUsers.Queries.Profile
{
    using Mapping;
    using MyPet.Domain.CompanyUsers.Models;

    public class CompanyUserProfileOutputModel : IMapFrom<CompanyUser>
    {
        public string LegalityRegistrationNumber { get; private set; }

        public string ApplicationUserId { get; private set; }

        public string CompanyName { get; private set; }

        public string OwnerName { get; private set; }

        public string Address { get; private set; }
    }
}
