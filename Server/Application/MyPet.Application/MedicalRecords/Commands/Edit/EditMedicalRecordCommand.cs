namespace MyPet.Application.MedicalRecords.Commands.Edit
{
    using MediatR;
    using MyPet.Application.Common;

    public class EditMedicalRecordCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}
