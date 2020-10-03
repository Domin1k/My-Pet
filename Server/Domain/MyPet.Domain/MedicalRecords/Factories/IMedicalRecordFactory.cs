namespace MyPet.Domain.MedicalRecords.Factories
{
    using MyPet.Domain.Common.Factories;
    using MyPet.Domain.MedicalRecords.Factories.Nested;
    using MyPet.Domain.MedicalRecords.Models;
    using System;

    public interface IMedicalRecordFactory : IFactory<MedicalRecord>
    {
        IMedicalRecordFactory WithAnimalName(string animalName);
        
        IMedicalRecordFactory WithAnimalAge(int animalAge);

        IMedicalRecordFactory WithBreed(string breed, Species species);

        IMedicalRecordFactory WithBreed(Breed breed);
    }
}
