namespace MyPet.Application.MedicalRecords.Commands.Create
{
    using MediatR;
    using MyPet.Application.Common;

    public class CreateMedicalRecordCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
