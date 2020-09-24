namespace MyPet.Domain.MedicalRecords.Models
{
    using Bogus;
    using MyPet.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreatmentFakes
    {
        public static class Data
        {
            public static IEnumerable<Treatment> GetTreatments(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetTreatment(i))
                    .ToList();

            public static Treatment GetTreatment(int id = 1)
                => new Faker<Treatment>()
                    .CustomInstantiator(f => new Treatment(
                        f.Company.CompanyName(),
                        f.Commerce.ProductDescription(),
                        f.Image.PicsumUrl(),
                        f.Date.Between(DateTime.Now, DateTime.Now.AddDays(30))))
                    .Generate()
                    .SetId(id);
        }
    }
}
