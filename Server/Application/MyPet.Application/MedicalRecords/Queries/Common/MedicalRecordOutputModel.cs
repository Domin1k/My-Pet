namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using System.Collections.Generic;

    public abstract class MedicalRecordOutputModel
    {
        public int Id { get; set; }

        public string AnimalName { get; set; }

        public int AnimalAge { get; set; }

        public string BreedName { get; set; }

        public string Species { get; set; }

        public IEnumerable<TreatmentOutputModel> Treatments { get; set; }
    }
}
