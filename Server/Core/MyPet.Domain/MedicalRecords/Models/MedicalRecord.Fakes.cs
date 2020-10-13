namespace MyPet.Domain.MedicalRecords.Models
{
    using Bogus;
    using FakeItEasy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Models;

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
            {
                var data = Enumerable
                    .Range(1, count)
                    .Select(x => GetMedicalRecord(x))
                    .ToList();
                return data;
            }

            public static MedicalRecord GetMedicalRecord(int id = 1, int totalTreatments = 5)
            {
                var medicalRecord = new Faker<MedicalRecord>()
                    .CustomInstantiator(f => new MedicalRecord(
                        $"AnimalName{id}",
                        f.Random.Number(1, 20),
                        new Breed($"Test{id}", Enumeration.FromValue<Species>(id))))
                    .Generate()
                    .SetId(id);

                foreach (var treatment in TreatmentFakes.Data.GetTreatments().Take(totalTreatments))
                {
                    medicalRecord.AddTreatment(treatment.Title, treatment.Description, treatment.ImageUrl, treatment.Next);
                }

                return medicalRecord;
            }
        }
    }
}
