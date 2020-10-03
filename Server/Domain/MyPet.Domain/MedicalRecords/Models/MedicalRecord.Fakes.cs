namespace MyPet.Domain.MedicalRecords.Models
{
    using Bogus;
    using FakeItEasy;
    using MyPet.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MedicalRecordFakes
    {
        public class MedicalRecordDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(MedicalRecord);

            public object Create(Type type) => Data.GetMedicalRecord();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<MedicalRecord> GetMedicalRecords(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetMedicalRecord)
                    .ToList();

            public static MedicalRecord GetMedicalRecord(int id = 1, int totalTreatments = 10)
            {
                var dealer = new Faker<MedicalRecord>()
                    .CustomInstantiator(f => new MedicalRecord(
                        $"AnimalName{id}",
                        f.Random.Number(1, 20),
                        A.Dummy<Breed>()))
                    .Generate()
                    .SetId(id);

                foreach (var treatment in TreatmentFakes.Data.GetTreatments().Take(totalTreatments))
                {
                    dealer.AddTreatment(treatment.Title, treatment.Description, treatment.ImageUrl, treatment.Next);
                }

                return dealer;
            }
        }
    }
}
