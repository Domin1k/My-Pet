using System;

namespace MyPet.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

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
