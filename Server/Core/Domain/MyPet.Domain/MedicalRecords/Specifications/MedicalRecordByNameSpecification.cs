namespace MyPet.Domain.MedicalRecords.Specifications
{
    using MyPet.Domain.Common;
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Linq.Expressions;

    public class MedicalRecordByNameSpecification : Specification<MedicalRecord>
    {
        private readonly string animalName;

        public MedicalRecordByNameSpecification(string animalName) 
            => this.animalName = animalName;

        protected override bool Include => !string.IsNullOrEmpty(this.animalName);

        public override Expression<Func<MedicalRecord, bool>> ToExpression()
                    => medRecord => medRecord.AnimalName.Contains(this.animalName) ;
    }
}
