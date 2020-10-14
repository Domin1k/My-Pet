namespace MyPet.Application.AdoptionAds.Queries.Search
{
    using MediatR;
    using MyPet.Application.AdoptionAds.Queries.Common;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.AdoptionAds.Specifications;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public class AdoptionAdSearchQuery : PageModel, IRequest<IEnumerable<AdoptionAdSearchOutputModel>>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public class AdoptionAdSearchQueryHandler : IRequestHandler<AdoptionAdSearchQuery, IEnumerable<AdoptionAdSearchOutputModel>>
        {
            private readonly IAdoptionAdQueryRepository adoptionAdQueryRepository;

            public AdoptionAdSearchQueryHandler(IAdoptionAdQueryRepository adoptionAdQueryRepository) 
                => this.adoptionAdQueryRepository = adoptionAdQueryRepository;

            public async Task<IEnumerable<AdoptionAdSearchOutputModel>> Handle(AdoptionAdSearchQuery request, CancellationToken cancellationToken)
                => await this
                        .adoptionAdQueryRepository
                        .GetAdoptionAds(
                            this.GetAdoptionAdSpecification(request),
                            new AdoptionAdSortOrder(request.SortBy, request.Order),
                            skip: (request.Page) * RecordsPerPage,
                            take: RecordsPerPage,
                            cancellationToken);

            private Specification<AdoptionAd> GetAdoptionAdSpecification(AdoptionAdSearchQuery request)
                => new AdoptionAdByTitleSpecification(request.Title)
                        .And(new AdoptionAdByCategorySpecification(request.Category))
                        .And(new AdoptionAdByDescriptionSpecification(request.Description));
        }
    }
}
