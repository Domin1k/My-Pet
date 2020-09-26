namespace MyPet.Application.AdoptionAds.Commands.Create
{
    using MediatR;
    using MyPet.Application.AdoptionAds.Commands.Common;
    using MyPet.Domain.AdoptionAds.Factories;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateAdoptionAdCommand : AdoptionAdInputModel, IRequest<CreateAdoptionAdOutputModel>
    {
        public class CreateAdoptionAdCommandHandler : IRequestHandler<CreateAdoptionAdCommand, CreateAdoptionAdOutputModel>
        {
            private readonly IAdoptionAdRepository adoptionAdRepository;
            private readonly IAdoptionAdFactory adoptionAdFactory;

            public CreateAdoptionAdCommandHandler(IAdoptionAdRepository adoptionAdRepository, IAdoptionAdFactory adoptionAdFactory)
            {
                this.adoptionAdRepository = adoptionAdRepository;
                this.adoptionAdFactory = adoptionAdFactory;
            }

            public async Task<CreateAdoptionAdOutputModel> Handle(CreateAdoptionAdCommand request, CancellationToken cancellationToken)
            {
                var category = await this.adoptionAdRepository.GetAdoptionCategory(request.CategoryName);
                var categoryName = category == null ? request.CategoryName : category.Name;
                var adoptionAd = this.adoptionAdFactory
                        .WithTitle(request.Title)
                        .WithDescription(request.Description)
                        .WithPublisherId(request.PublisherId)
                        .WithCategory(categoryName)
                        .Build();

                await this.adoptionAdRepository.Save(adoptionAd, cancellationToken);

                return new CreateAdoptionAdOutputModel(adoptionAd.Id);
            }
        }
    }
}
