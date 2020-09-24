namespace MyPet.Domain.MedicalRecords.Models
{
    using FakeItEasy;
    using System;

    public class BreedFakes
    {
        public class BreedDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Breed);

            public object Create(Type type)
                => new Breed("Pom", Species.Dog);

            public Priority Priority => Priority.Default;
        }
    }
}
