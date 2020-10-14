namespace MyPet.Application.MedicalRecords.Queries.Search
{
    using AutoMapper;
    using Domain.Models;
    using Mapping;
    using MyPet.Application.MedicalRecords.Queries.Common;
    using MyPet.Domain.MedicalRecords.Models;

    public class MedicalRecordSearchOutputModel : MedicalRecordOutputModel, IMapFrom<MedicalRecord>
    {
        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<MedicalRecord, MedicalRecordSearchOutputModel>()
                .ForMember(d => d.Treatments, cfg => cfg.MapFrom(s => s.Treatments))
                .ForMember(d => d.BreedName, cfg => cfg.MapFrom(s => s.AnimalBreed.BreedName))
                .ForMember(d => d.Species, cfg => cfg.MapFrom(s => Enumeration.NameFromValue<Species>(s.AnimalBreed.Species.Value)));
    }
}