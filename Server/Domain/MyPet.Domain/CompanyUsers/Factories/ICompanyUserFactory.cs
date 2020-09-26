namespace MyPet.Domain.CompanyUsers.Factories
{
    using MyPet.Domain.Common.Factories;
    using MyPet.Domain.CompanyUsers.Models;

    public interface ICompanyUserFactory : IFactory<CompanyUser>
    {
        ICompanyUserFactory WithApplicationUserId(string applicationUserId);

        ICompanyUserFactory WithCompanyName(string companyName);

        ICompanyUserFactory WithOwnerName(string ownerName);

        ICompanyUserFactory WithAddress(string address);

        ICompanyUserFactory WithLegalityRegistrationNumber(string legalityRegistrationNumber);
    }
}
