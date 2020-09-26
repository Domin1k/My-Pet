namespace MyPet.Application.AdoptionAds.Queries.Details
{
    using MediatR;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class AdoptionAdDetailsQuery : EntityCommand<int>, IRequest<AdoptionAdDetailsOutputModel>
    {
        public class AdoptionAdDetailsQueryHandler : IRequestHandler<AdoptionAdDetailsQuery, AdoptionAdDetailsOutputModel>
        {
            private readonly IAdoptionAdRepository adoptionAdRepository;

            public AdoptionAdDetailsQueryHandler(IAdoptionAdRepository adoptionAdRepository) 
                => this.adoptionAdRepository = adoptionAdRepository;

            public Task<AdoptionAdDetailsOutputModel> Handle(AdoptionAdDetailsQuery request, CancellationToken cancellationToken)
                => this.adoptionAdRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
