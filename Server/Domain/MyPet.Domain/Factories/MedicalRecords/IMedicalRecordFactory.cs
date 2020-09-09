namespace MyPet.Domain.Factories.MedicalRecords
{
    using MyPet.Domain.Models;
    using MyPet.Domain.Models.MedicalRecords;

    public interface IMedicalRecordFactory : IFactory<MedicalRecord>
    {
        IMedicalRecordFactory WithAnimalName(string animalName);
        
        IMedicalRecordFactory WithAnimalAge(int animalAge);

        IMedicalRecordFactory WithOwnerFullName(string ownerFullName);

        IMedicalRecordFactory WithBreed(string breed, Species species);

        IMedicalRecordFactory WithBreed(Breed breed);
    }
}
