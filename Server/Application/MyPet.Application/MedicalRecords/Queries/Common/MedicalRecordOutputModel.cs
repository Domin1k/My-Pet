namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using System.Collections.Generic;

    public abstract class MedicalRecordOutputModel
    {
        public string AnimalName { get; private set; }

        public int AnimalAge { get; private set; }

        public string BreedName { get; private set; }

        public string Species { get; private set; }

        public IEnumerable<TreatmentOutputModel> Treatments { get; private set; }
    }
}
