namespace MyPet.Domain.AdoptionAds.Models
{
    using FakeItEasy;
    using Bogus;
    using MyPet.Domain.CompanyUsers.Models;
    using System;
    using MyPet.Domain.Common.Models;

    public class AdoptionAdFakes
    {
        public class AdoptionAdDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(AdoptionAd);

            public object Create(Type type) => Data.GetAdoptionAd();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static AdoptionAd GetAdoptionAd(int id = 1)
            {
                var adoptionAd = new Faker<AdoptionAd>()
                    .CustomInstantiator(f => new AdoptionAd(
                        f.Commerce.ProductName(),
                        f.Commerce.ProductDescription(),
                        CompanyUserFakes.CompanyUserFakeApplicationId.ToString(),
                        A.Dummy<AdoptionCategory>()))
                    .Generate()
                    .SetId(id);


                return adoptionAd;
            }
        }
    }
}
