namespace MyPet.Domain.MedicalRecords.Models
{
    using Domain.Models;
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

        public string BreedName { get; private set; }

        public Species Species { get; private set; }

        private void Validate(string breedName)
            => Guard.ForStringLength<InvalidMedicalRecordException>(
               breedName,
               MedicalRecordConstants.MedicalRecord.MinBreedLength,
               MedicalRecordConstants.MedicalRecord.MaxBreedLength,
               nameof(this.BreedName));
    }
}
