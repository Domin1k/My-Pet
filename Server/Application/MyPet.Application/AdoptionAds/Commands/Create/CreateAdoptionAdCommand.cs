namespace MyPet.Application.AdoptionAds.Commands.Create
{
    using MediatR;
    using MyPet.Application.Common;

    public class CreateAdoptionAdCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
