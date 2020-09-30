namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using MyPet.Application.Common;
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
            => this.SortBy switch
            {
                "animalName" => medicalRecord => medicalRecord.AnimalName,
                _ => medicalRecord => medicalRecord.Id
            };
    }
}
