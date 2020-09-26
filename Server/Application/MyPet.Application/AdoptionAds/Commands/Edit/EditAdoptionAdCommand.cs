namespace MyPet.Application.AdoptionAds.Commands.Edit
{
    using MediatR;
    using MyPet.Application.AdoptionAds.Commands.Common;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditAdoptionAdCommand : AdoptionAdInputModel, IRequest<Result>
    {
        public class EditAdoptionAdCommandHanddler : IRequestHandler<EditAdoptionAdCommand, Result>
        {
            private readonly IAdoptionAdRepository adoptionAdRepository;

            public EditAdoptionAdCommandHanddler(IAdoptionAdRepository adoptionAdRepository) 
                => this.adoptionAdRepository = adoptionAdRepository;

            public async Task<Result> Handle(EditAdoptionAdCommand request, CancellationToken cancellationToken)
            {
                var adoptionAd = await this.adoptionAdRepository.Find(request.Id, cancellationToken);

                adoptionAd
                        .UpdateTitle(request.Title)
                        .UpdateDescription(request.Description)
                        .UpdateCategory(request.CategoryName);

                await this.adoptionAdRepository.Save(adoptionAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
