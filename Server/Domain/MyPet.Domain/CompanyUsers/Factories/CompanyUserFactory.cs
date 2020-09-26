namespace MyPet.Domain.CompanyUsers.Factories
{
    using MyPet.Domain.CompanyUsers.Models;

    internal class CompanyUserFactory : ICompanyUserFactory
    {
        private string applicationUserId;
        private string name;
        private string ownerName;
        private string legalityRegistrationNumber;
        private string address;

        public ICompanyUserFactory WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public ICompanyUserFactory WithApplicationUserId(string applicationUserId)
        {
            this.applicationUserId = applicationUserId;
            return this;
        }

        public ICompanyUserFactory WithLegalityRegistrationNumber(string legalityRegistrationNumber)
        {
            this.legalityRegistrationNumber = legalityRegistrationNumber;
            return this;
        }

        public ICompanyUserFactory WithCompanyName(string name)
        {
            this.name = name;
            return this;
        }

        public ICompanyUserFactory WithOwnerName(string ownerName)
        {
            this.ownerName = ownerName;
            return this;
        }

        public CompanyUser Build()
        {
            return new CompanyUser(
                applicationUserId,
                name,
                ownerName,
                address,
                legalityRegistrationNumber);
        }
    }
}
