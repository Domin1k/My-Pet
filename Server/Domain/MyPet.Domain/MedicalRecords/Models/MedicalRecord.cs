namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Exceptions;
    using System.Collections.Generic;
    using System.Linq;

    public class MedicalRecord : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Treatment> treatments;

        internal MedicalRecord(string animalName, int animalAge, Breed breed)
        {
            this.Validate(animalName, animalAge);

            this.AnimalName = animalName;
            this.AnimalAge = animalAge;
            this.AnimalBreed = breed;

            this.treatments = new HashSet<Treatment>();
        }

        private MedicalRecord(string animalName, int animalAge)
        {
            this.AnimalName = animalName;
            this.AnimalAge = animalAge;

            this.treatments = new HashSet<Treatment>();
        }

        public string AnimalName { get;  }

        public int AnimalAge { get; }

        public Breed AnimalBreed { get; }

        public IReadOnlyCollection<Treatment> Treatments => this.treatments.ToList().AsReadOnly();

        public MedicalRecord AddTreatment(Treatment treatment)
        {
            this.treatments.Add(treatment);
            return this;
        }

        public void Validate(string animalName, int animalAge)
        {
            Guard.ForStringLength<InvalidMedicalRecordException>(
               animalName,
               ModelConstants.Common.MinNameLength,
               ModelConstants.Common.MaxNameLength,
               nameof(this.AnimalName));

            Guard.AgainstOutOfRange<InvalidMedicalRecordException>(
               animalAge,
               MedicalRecordConstants.MedicalRecord.MinAge,
               MedicalRecordConstants.MedicalRecord.MaxAge,
               nameof(this.AnimalAge));
        }
    }
}
