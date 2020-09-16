namespace MyPet.Domain.MedicalRecords.Factories
{
    using MyPet.Domain.MedicalRecords.Models;

    internal class MedicalRecordFactory : IMedicalRecordFactory
    {
        private int animalAge;
        private string animalName;
        private string ownerFullName;
        private Breed breed;

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

        public IMedicalRecordFactory WithOwnerFullName(string ownerFullName)
        {
            this.ownerFullName = ownerFullName;
            return this;
        }

        public IMedicalRecordFactory WithBreed(string breed, Species species)
            => this.WithBreed(new Breed(breed, species));

        public IMedicalRecordFactory WithBreed(Breed breed)
        {
            this.breed = breed;
            return this;
        }

        public MedicalRecord Build()
            => new MedicalRecord(
                this.animalName,
                this.animalAge,
                this.ownerFullName,
                this.breed);
    }
}
