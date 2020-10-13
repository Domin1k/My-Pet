namespace MyPet.Domain.CompanyUsers.Factories
{
    using MyPet.Domain.CompanyUsers.Models;
    using System;
    using Domain.Factories;

    public interface ICompanyUserFactory : IFactory<CompanyUser>
    {
        ICompanyUserFactory WithApplicationUserId(Guid applicationUserId);

        ICompanyUserFactory WithCompanyName(string companyName);

        ICompanyUserFactory WithCompanyEmail(string email);

        ICompanyUserFactory WithOwnerName(string ownerName);

        ICompanyUserFactory WithAddress(string address);

        ICompanyUserFactory WithLegalityRegistrationNumber(string legalityRegistrationNumber);
    }
}
