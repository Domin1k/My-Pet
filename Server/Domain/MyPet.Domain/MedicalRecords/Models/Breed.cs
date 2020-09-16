namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Exceptions;

    public class Breed : ValueObject
    {
        internal Breed(string breed, Species species)
        {
            this.Validate(breed);

            this.BreedName = breed;
            this.Species = species;
        }

        public string BreedName { get; }

        public Species Species { get; }

        private void Validate(string breed)
            => Guard.ForStringLength<InvalidMedicalRecordException>(
               breed,
               MedicalRecordConstants.MedicalRecord.MinBreedLength,
               MedicalRecordConstants.MedicalRecord.MaxBreedLength,
               nameof(this.BreedName));
    }
}
