namespace MyPet.Domain.MedicalRecords.Factories
{
    using MyPet.Domain.MedicalRecords.Factories.Nested;
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Collections.Generic;

    internal class MedicalRecordFactory : IMedicalRecordFactory
    {
        private int animalAge;
        private string animalName;
        private Breed breed;

        private readonly TreatmentFactory treatmentFactory = new TreatmentFactory();
        private readonly List<Treatment> treatments = new List<Treatment>();

        public IMedicalRecordFactory WithAnimalAge(int animalAge)
        {
            this.animalAge = animalAge;
            return this;
        }

        public IMedicalRecordFactory WithAnimalName(string animalName)
        {
            this.animalName = animalName;
            return this;
        }

        public IMedicalRecordFactory WithBreed(string breed, Species species)
            => this.WithBreed(new Breed(breed, species));

        public IMedicalRecordFactory WithBreed(Breed breed)
        {
            this.breed = breed;
            return this;
        }

        public IMedicalRecordFactory WithTreatment(Action<TreatmentFactory> treatment)
        {
            treatment(this.treatmentFactory);
            this.treatments.Add(this.treatmentFactory.Build());
            return this;
        }

        public MedicalRecord Build()
        {
            var medicalRecord = new MedicalRecord(
               this.animalName,
               this.animalAge,
               this.breed);

            this.treatments.ForEach(t => medicalRecord.AddTreatment(t));

            return medicalRecord;
        }
    }
}
