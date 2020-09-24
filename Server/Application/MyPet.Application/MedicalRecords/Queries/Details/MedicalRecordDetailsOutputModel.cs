namespace MyPet.Application.MedicalRecords.Queries.Details
{
    using AutoMapper;
    using MyPet.Application.Common.Mapping;
    using MyPet.Application.MedicalRecords.Queries.Common;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Collections.Generic;

    public class MedicalRecordDetailsOutputModel : IMapFrom<MedicalRecord>
    {
        public string AnimalName { get; private set; }

        public int AnimalAge { get; private set; }

        public string BreedName { get; private set; }

        public string Species { get; private set; }

        public IEnumerable<TreatmentOutputModel> Treatments { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<MedicalRecord, MedicalRecordDetailsOutputModel>()
                .ForMember(d => d.Treatments, cfg => cfg.MapFrom(s => s.Treatments))
                .ForMember(d => d.BreedName, cfg => cfg.MapFrom(s => s.AnimalBreed.BreedName))
                .ForMember(d => d.Species, cfg => cfg.MapFrom(s => Enumeration.NameFromValue<Species>(s.AnimalBreed.Species.Value)));

    }
}
