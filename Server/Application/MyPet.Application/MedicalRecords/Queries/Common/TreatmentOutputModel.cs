namespace MyPet.Application.MedicalRecords.Queries.Common
{
    using MyPet.Application.Common.Mapping;
    using MyPet.Domain.MedicalRecords.Models;
    using System;

    public class TreatmentOutputModel : IMapFrom<Treatment>
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        public DateTime? Next { get; private set; }
    }
}
