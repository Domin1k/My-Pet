namespace MyPet.Application.AdoptionAds.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteAdoptionAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteAdoptionAdCommandHandler : IRequestHandler<DeleteAdoptionAdCommand, Result>
        {
            private readonly IAdoptionAdRepository adoptionAdRepository;

            public DeleteAdoptionAdCommandHandler(IAdoptionAdRepository adoptionAdRepository) 
                => this.adoptionAdRepository = adoptionAdRepository;

            public async Task<Result> Handle(DeleteAdoptionAdCommand request, CancellationToken cancellationToken)
                => await this.adoptionAdRepository.Delete(request.Id, cancellationToken);
        }
    }
}
