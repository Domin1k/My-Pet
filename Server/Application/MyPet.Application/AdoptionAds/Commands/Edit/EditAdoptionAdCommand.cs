namespace MyPet.Application.AdoptionAds.Commands.Edit
{
    using MediatR;
    using MyPet.Application.Common;

    public class EditAdoptionAdCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
