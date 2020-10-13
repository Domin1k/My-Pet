namespace MyPet.Domain.AdoptionAds.Models
{
    using Bogus;
    using FakeItEasy;
    using System;
    using Domain.Models;

    public class AdoptionCategoryFakes
    {
        public class AdoptionCategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(AdoptionCategory);

            public object Create(Type type) => Data.GetAdoptionCategory();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static AdoptionCategory GetAdoptionCategory(int id = 1)
            {
                var adoptionAdCategory = new Faker<AdoptionCategory>()
                    .CustomInstantiator(f => new AdoptionCategory(
                        f.Random.String(10)))
                    .Generate()
                    .SetId(id);

                return adoptionAdCategory;
            }
        }
    }
}
