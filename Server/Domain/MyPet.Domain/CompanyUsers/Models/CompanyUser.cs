namespace MyPet.Domain.CompanyUsers.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.CompanyUsers.Events;
    using MyPet.Domain.CompanyUsers.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyUser : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<int> medicalRecordsIds;

        internal CompanyUser(Guid applicationUserId, string companyName, string ownerName, string address, string legalityRegistrationNumber, string companyEmail)
        {
            this.Validate(companyName, ownerName, address, legalityRegistrationNumber, applicationUserId, companyEmail);

            this.ApplicationUserId = applicationUserId;
            this.CompanyName = companyName;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;
            this.CompanyEmail = companyEmail;

            this.medicalRecordsIds = new HashSet<int>();
        }

        private CompanyUser(string companyName, string ownerName, string address, string legalityRegistrationNumber)
        {
            this.CompanyName = companyName;
            this.OwnerName = ownerName;
            this.Address = address;
            this.LegalityRegistrationNumber = legalityRegistrationNumber;

            this.medicalRecordsIds = new HashSet<int>();
        }

        public string LegalityRegistrationNumber { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public string CompanyName { get; private set; }

        public string CompanyEmail { get; private set; }

        public string OwnerName { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyCollection<int> MedicalRecords => this.medicalRecordsIds.ToList().AsReadOnly();

        public CompanyUser AddMedicalRecord(int medicalRecordId)
        {
            this.medicalRecordsIds.Add(medicalRecordId);
            this.AddEvent(new MedicalRecordAddedEvent(medicalRecordId));

            return this;
        }

        public CompanyUser UpdateOwnerName(string ownerName)
        {
            this.ValidateOwnerName(ownerName);
            this.OwnerName = ownerName;
            return this;
        }

        public CompanyUser UpdateLegalityRegistrationNumber(string legalityRegistrationNumber)
        {
            this.ValidateLegalityRegistrationNumber(legalityRegistrationNumber);
            this.LegalityRegistrationNumber = legalityRegistrationNumber;
            return this;
        }

        public CompanyUser UpdateCompanyName(string companyName)
        {
            this.ValidateCompany(companyName);
            this.CompanyName = companyName;
            return this;
        }

        public CompanyUser UpdateCompanyEmail(string email)
        {
            this.ValidateEmail(email);
            this.CompanyEmail = email;
            return this;
        }

        public CompanyUser UpdateAddress(string address)
        {
            this.ValidateAddress(address);
            this.Address = address;
            return this;
        }

        private void Validate(string companyName, string ownerName, string address, string legalityCode, Guid applicationUserId, string companyEmail)
        {
            this.ValidateCompany(companyName);
            this.ValidateOwnerName(ownerName);
            this.ValidateAddress(address);
            this.ValidateLegalityRegistrationNumber(legalityCode);
            this.ValidateEmail(companyEmail);

            if (applicationUserId == Guid.Empty)
            {
                throw new InvalidCompanyUserException($"{nameof(this.ApplicationUserId)} cannot be empty or null");
            }
        }

        private void ValidateEmail(string companyEmail)
        {
            Guard.ForStringLength<InvalidCompanyUserException>(
                companyEmail,
                ModelConstants.Common.MinEmailLength,
                ModelConstants.Common.MaxEmailLength,
                nameof(this.CompanyEmail));

            Guard.ForEmailAddress<InvalidCompanyUserException>(
                companyEmail,
                nameof(this.CompanyEmail));
        }

        private void ValidateCompany(string companyName)
            => Guard.ForStringLength<InvalidCompanyUserException>(
               companyName,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.CompanyName));

        private void ValidateOwnerName(string ownerName)
            => Guard.ForStringLength<InvalidCompanyUserException>(
                ownerName,
                CompanyUsersConstants.CompanyUser.MinOwnerName,
                CompanyUsersConstants.CompanyUser.MaxOwnerName,
                nameof(this.OwnerName));

        private void ValidateAddress(string address)
            => Guard.ForStringLength<InvalidCompanyUserException>(
                address,
                CompanyUsersConstants.CompanyUser.MinAddressLength,
                CompanyUsersConstants.CompanyUser.MaxAddressLength,
                nameof(this.Address));

        private void ValidateLegalityRegistrationNumber(string legalityCode)
            => Guard.ForStringLength<InvalidCompanyUserException>(
               legalityCode,
               CompanyUsersConstants.CompanyUser.MinLegalityRegistrationNumberLength,
               CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength,
               nameof(this.LegalityRegistrationNumber));
    }
}
