namespace MyPet.Domain.MedicalRecords.Models
{
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Exceptions;

    public class Breed : ValueObject
    {
        internal Breed(string breedName, Species species)
        {
            this.Validate(breedName);

            this.BreedName = breedName;
            this.Species = species;
        }

        private Breed(string breedName) 
            => this.BreedName = breedName;

        public string BreedName { get; }

        public Species Species { get; }

        private void Validate(string breedName)
            => Guard.ForStringLength<InvalidMedicalRecordException>(
               breedName,
               MedicalRecordConstants.MedicalRecord.MinBreedLength,
               MedicalRecordConstants.MedicalRecord.MaxBreedLength,
               nameof(this.BreedName));
    }
}
