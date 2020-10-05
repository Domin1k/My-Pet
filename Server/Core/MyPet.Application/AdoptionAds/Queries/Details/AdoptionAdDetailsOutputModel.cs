namespace MyPet.Application.AdoptionAds.Queries.Details
{
    using AutoMapper;
    using MyPet.Application.Common.Mapping;
    using MyPet.Domain.AdoptionAds.Models;

    public class AdoptionAdDetailsOutputModel : IMapFrom<AdoptionAd>
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public string PublisherId { get; private set; }

        public string CategoryName { get; private set; }

        public void Mapping(Profile mapper)
            => mapper.CreateMap<AdoptionAd, AdoptionAdDetailsOutputModel>()
            .ForMember(d => d.CategoryName, cfg => cfg.MapFrom(s => s.Category.Name));
    }
}
