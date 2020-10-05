namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Exceptions;
    using System;
    using System.Collections.Generic;

    public class MedicalRecord : Entity<int>, IAggregateRoot
    {
        private readonly List<Treatment> treatments;

        internal MedicalRecord(string animalName, int animalAge, Breed breed)
        {
            this.ValidateName(animalName);
            this.ValidateAge(animalAge);

            this.AnimalName = animalName;
            this.AnimalAge = animalAge;
            this.AnimalBreed = breed;

            this.treatments = new List<Treatment>();
        }

        private MedicalRecord(string animalName, int animalAge)
        {
            this.AnimalName = animalName;
            this.AnimalAge = animalAge;

            this.treatments = new List<Treatment>();
        }

        public string AnimalName { get; private set; }

        public int AnimalAge { get; private set; }

        public Breed AnimalBreed { get; private set; }

        public IReadOnlyCollection<Treatment> Treatments => this.treatments.AsReadOnly();

        public MedicalRecord AddTreatment(string title, string description, string imageUrl, DateTime? next)
        {
            this.treatments.Add(new Treatment(title, description, imageUrl, next));
            return this;
        }

        public MedicalRecord UpdateAnimalAge(int animalAge)
        {
            this.ValidateAge(animalAge);
            this.AnimalAge = animalAge;
            return this;
        }

        public MedicalRecord UpdateAnimalName(string animalName)
        {
            this.ValidateName(animalName);
            this.AnimalName = animalName;
            return this;
        }

        public MedicalRecord UpdateAnimalBreed(string breedName)
        {
            var breed = new Breed(breedName, this.AnimalBreed.Species);
            this.AnimalBreed = breed;
            return this;
        }

        public MedicalRecord UpdateAnimalSpeciesAndBreed(string breedName, string species)
        {
            this.AnimalBreed = new Breed(breedName, Enumeration.FromName<Species>(species));
            return this;
        }

        private void ValidateName(string animalName)
            => Guard.ForStringLength<InvalidMedicalRecordException>(
                   animalName,
                   ModelConstants.Common.MinNameLength,
                   ModelConstants.Common.MaxNameLength,
                   nameof(this.AnimalName));

        private void ValidateAge(int animalAge)
            => Guard.AgainstOutOfRange<InvalidMedicalRecordException>(
                   animalAge,
                   MedicalRecordConstants.MedicalRecord.MinAge,
                   MedicalRecordConstants.MedicalRecord.MaxAge,
                   nameof(this.AnimalAge));
    }
}
