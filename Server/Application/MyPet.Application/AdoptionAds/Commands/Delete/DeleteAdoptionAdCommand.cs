namespace MyPet.Application.AdoptionAds.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;

    public class DeleteAdoptionAdCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
