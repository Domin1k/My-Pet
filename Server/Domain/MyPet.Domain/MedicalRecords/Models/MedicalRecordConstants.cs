namespace MyPet.Domain.MedicalRecords.Models
{
    public class MedicalRecordConstants
    {
        public class MedicalRecord
        {
            public const int MinAge = 0;
            public const int MaxAge = 255;
            public const int MinBreedLength = 2;
            public const int MaxBreedLength = 100;
        }

        public class Treatment
        {
            public const int MinTreatmentTitleLength = 2;
            public const int MaxTreatmentTitleLength = 100;
            public const int MaxTreatmentDescriptionLength = 500;
        }
    }
}
