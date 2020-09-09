namespace MyPet.Domain.Models
{
    using MyPet.Domain.Common;
    using MyPet.Domain.Exceptions;
    using MyPet.Domain.Models.MedicalRecords;
    using System.Collections.Generic;

    public class MedicalRecord : AuditableEntity<int>, IAggregateRoot
    {
        internal MedicalRecord(string animalName, int animalAge, string ownerFullName, Breed breed)
        {
            this.Validate(animalName, animalAge, ownerFullName);

            this.AnimalName = animalName;
            this.AnimalAge = animalAge;
            this.OwnerFullName = ownerFullName;
            this.AnimalBreed = breed;

            this.Treatments = new List<Treatment>();
        }

        public string AnimalName { get;  }

        public int AnimalAge { get; }

        public string OwnerFullName { get; }

        public Breed AnimalBreed { get; }

        public ICollection<Treatment> Treatments { get; }

        public MedicalRecord AddTreatment(Treatment treatment)
        {
            // validate
            this.Treatments.Add(treatment);
            return this;
        }

        public void Validate(string animalName, int animalAge, string ownerFullName)
        {
            Guard.ForStringLength<InvalidMedicalRecordException>(
               animalName,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.AnimalName));

            Guard.ForStringLength<InvalidMedicalRecordException>(
               ownerFullName,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.OwnerFullName));

            Guard.AgainstOutOfRange<InvalidMedicalRecordException>(
               animalAge,
               ModelConstants.MedicalRecord.MinAge,
               ModelConstants.MedicalRecord.MaxAge,
               nameof(this.AnimalAge));
        }
    }
}
