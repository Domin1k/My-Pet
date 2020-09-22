namespace MyPet.Domain.CompanyUsers.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Exceptions;
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyUser : Entity<Guid>, IAggregateRoot
    {
        private readonly HashSet<MedicalRecord> medicalRecords;

        internal CompanyUser(string applicationUserId, string name, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.Validate(name, ownerName, address, legalityRegistrationNumber, applicationUserId);

            this.ApplicationUserId = applicationUserId;
            this.Name = name;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        private CompanyUser(string name, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.Name = name;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        public string LegalityRegistrationNumber { get; }

        public string ApplicationUserId { get; }

        public string Name { get; }

        public string OwnerName { get; }

        public string Address { get; }

        public IReadOnlyCollection<MedicalRecord> MedicalRecords => this.medicalRecords.ToList().AsReadOnly();

        public CompanyUser AddMedicalRecord(MedicalRecord medicalRecord)
        {
            this.medicalRecords.Add(medicalRecord);
            return this;
        }

        public void Validate(string name, string ownerName, string address, string legalityCode, string applicationUserId)
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
              nameof(this.LegalityRegistrationNumber));

            Guard.ForValidGuid<InvalidCompanyUserException>(
             applicationUserId,
             nameof(this.ApplicationUserId));
        }
    }
}
