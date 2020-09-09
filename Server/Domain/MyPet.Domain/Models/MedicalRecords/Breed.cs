using MyPet.Domain.Common;
using MyPet.Domain.Exceptions;

namespace MyPet.Domain.Models.MedicalRecords
{
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
               ModelConstants.MedicalRecord.MinBreedLength,
               ModelConstants.MedicalRecord.MaxBreedLength,
               nameof(this.BreedName));
    }
}
