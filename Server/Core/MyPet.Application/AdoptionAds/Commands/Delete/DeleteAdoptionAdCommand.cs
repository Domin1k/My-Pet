namespace MyPet.Application.AdoptionAds.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Domain.AdoptionAds;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteAdoptionAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteAdoptionAdCommandHandler : IRequestHandler<DeleteAdoptionAdCommand, Result>
        {
            private readonly IAdoptionAdDomainRepository adoptionAdRepository;

            public DeleteAdoptionAdCommandHandler(IAdoptionAdDomainRepository adoptionAdRepository) 
                => this.adoptionAdRepository = adoptionAdRepository;

            public async Task<Result> Handle(DeleteAdoptionAdCommand request, CancellationToken cancellationToken)
                => await this.adoptionAdRepository.Delete(request.Id, cancellationToken);
        }
    }
}
