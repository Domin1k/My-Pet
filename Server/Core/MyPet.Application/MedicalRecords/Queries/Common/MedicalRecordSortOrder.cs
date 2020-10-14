namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Linq.Expressions;

    public class MedicalRecordSortOrder : SortOrder<MedicalRecord>
    {
        public MedicalRecordSortOrder(string sortBy, string order)
           : base(sortBy, order)
        {
        }

        public override Expression<Func<MedicalRecord, object>> ToExpression()
        {
            if (string.IsNullOrEmpty(this.SortBy))
            {
                return medicalRecord => medicalRecord.Id;
            }
            return this.SortBy switch
            {
                "animalName" => medicalRecord => medicalRecord.AnimalName,
                _ => medicalRecord => medicalRecord.Id,
            };
        }
    }
}
