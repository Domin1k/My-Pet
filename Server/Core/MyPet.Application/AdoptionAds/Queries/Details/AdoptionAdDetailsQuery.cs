namespace MyPet.Application.AdoptionAds.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AdoptionAdDetailsQuery : EntityCommand<int>, IRequest<AdoptionAdDetailsOutputModel>
    {
        public class AdoptionAdDetailsQueryHandler : IRequestHandler<AdoptionAdDetailsQuery, AdoptionAdDetailsOutputModel>
        {
            private readonly IAdoptionAdQueryRepository adoptionAdRepository;

            public AdoptionAdDetailsQueryHandler(IAdoptionAdQueryRepository adoptionAdRepository) 
                => this.adoptionAdRepository = adoptionAdRepository;

            public Task<AdoptionAdDetailsOutputModel> Handle(AdoptionAdDetailsQuery request, CancellationToken cancellationToken)
                => this.adoptionAdRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
