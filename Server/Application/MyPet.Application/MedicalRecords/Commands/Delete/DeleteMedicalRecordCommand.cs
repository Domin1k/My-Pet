namespace MyPet.Application.MedicalRecords.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMedicalRecordCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteMedicalRecordCommandHandler : IRequestHandler<DeleteMedicalRecordCommand, Result>
        {
            public Task<Result> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
