namespace MyPet.Domain.CompanyUsers.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Events;
    using MyPet.Domain.CompanyUsers.Exceptions;
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyUser : Entity<Guid>, IAggregateRoot
    {
        private readonly HashSet<MedicalRecord> medicalRecords;

        internal CompanyUser(Guid applicationUserId, string companyName, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.Validate(companyName, ownerName, address, legalityRegistrationNumber, applicationUserId);

            this.ApplicationUserId = applicationUserId;
            this.CompanyName = companyName;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        private CompanyUser(string companyName, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.CompanyName = companyName;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        public string LegalityRegistrationNumber { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public string CompanyName { get; private set; }

        public string OwnerName { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyCollection<MedicalRecord> MedicalRecords => this.medicalRecords.ToList().AsReadOnly();

        public CompanyUser AddMedicalRecord(MedicalRecord medicalRecord)
        {
            this.medicalRecords.Add(medicalRecord);

            this.AddEvent(new MedicalRecordAddedEvent(medicalRecord.Id));
            return this;
        }

        public void Validate(string companyName, string ownerName, string address, string legalityCode, Guid applicationUserId)
        {
            Guard.ForStringLength<InvalidCompanyUserException>(
               companyName,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.CompanyName));

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

            if (applicationUserId == Guid.Empty)
            {
                throw new InvalidCompanyUserException($"{nameof(this.ApplicationUserId)} cannot be empty or null");
            }
        }
    }
}
