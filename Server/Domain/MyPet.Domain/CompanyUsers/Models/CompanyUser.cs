namespace MyPet.Domain.CompanyUsers.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyUser : Entity<Guid>, IAggregateRoot
    {
        private readonly HashSet<int> medicalRecords;

        internal CompanyUser(string applicationUserId, string name, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.Validate(name, ownerName, address, legalityRegistrationNumber);

            this.ApplicationUserId = applicationUserId;
            this.Name = name;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecords = new HashSet<int>();
        }

        public string LegalityRegistrationNumber { get; }

        public string ApplicationUserId { get; }

        public string Name { get; }

        public string OwnerName { get; }

        public string Address { get; }

        public IReadOnlyCollection<int> MedicalRecords => this.medicalRecords.ToList().AsReadOnly();

        public CompanyUser AddMedicalRecord(int medicalRecordId)
        {
            this.medicalRecords.Add(medicalRecordId);
            return this;
        }

        public void Validate(string name, string ownerName, string address, string legalityCode)
        {
            Guard.ForStringLength<InvalidCompanyUserException>(
               name,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.Name));

            Guard.ForStringLength<InvalidCompanyUserException>(
               ownerName,
               CompanyUsersConstants.CompanyUser.MinOwnerName,
               CompanyUsersConstants.CompanyUser.MaxOwnerName,
               nameof(this.OwnerName));

            Guard.ForStringLength<InvalidCompanyUserException>(
               address,
               CompanyUsersConstants.CompanyUser.MinAddressLength,
               CompanyUsersConstants.CompanyUser.MaxAddressLength,
               nameof(this.Address));

            Guard.ForStringLength<InvalidCompanyUserException>(
              legalityCode,
              CompanyUsersConstants.CompanyUser.MinLegalityRegistrationNumberLength,
              CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength,
              nameof(this.Address));
        }
    }
}
