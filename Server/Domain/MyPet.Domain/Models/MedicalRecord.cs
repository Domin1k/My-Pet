namespace MyPet.Domain.Models
{
    using MyPet.Domain.Common;
    using MyPet.Domain.Exceptions;
    using System.Collections.Generic;

    public class MedicalRecord : AuditableEntity<int>
    {
        public MedicalRecord(string animalName, int animalAge, Species animalSpecies, string ownerFullName, string breed)
        {
            this.Validate(animalName, animalAge, ownerFullName, breed);

            this.AnimalName = animalName;
            this.AnimalAge = animalAge;
            this.AnimalSpecies = animalSpecies;
            this.OwnerFullName = ownerFullName;
            this.AnimalBreed = breed;
            this.Treatments = new List<Treatment>();
        }

        public string AnimalName { get;  }

        public int AnimalAge { get; }

        public Species AnimalSpecies { get; }

        public string OwnerFullName { get; }

        public string AnimalBreed { get; }

        public ICollection<Treatment> Treatments { get; }

        public MedicalRecord AddTreatment(Treatment treatment)
        {
            // validate
            this.Treatments.Add(treatment);
            return this;
        }

        public void Validate(string animalName, int animalAge, string ownerFullName, string breed)
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

            Guard.ForStringLength<InvalidMedicalRecordException>(
               breed,
               ModelConstants.MedicalRecord.MinBreedLength,
               ModelConstants.MedicalRecord.MaxBreedLength,
               nameof(this.AnimalBreed));

            Guard.AgainstOutOfRange<InvalidMedicalRecordException>(
               animalAge,
               ModelConstants.MedicalRecord.MinAge,
               ModelConstants.MedicalRecord.MaxAge,
               nameof(this.AnimalAge));
        }
    }
}
