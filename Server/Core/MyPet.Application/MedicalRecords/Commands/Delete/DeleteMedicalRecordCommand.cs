namespace MyPet.Application.MedicalRecords.Commands.Delete
{
    using MediatR;
    using MyPet.Domain.MedicalRecords;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMedicalRecordCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteMedicalRecordCommandHandler : IRequestHandler<DeleteMedicalRecordCommand, Result>
        {
            private readonly IMedicalRecordDomainRepository medicalRecordRepository;

            public DeleteMedicalRecordCommandHandler(IMedicalRecordDomainRepository medicalRecordRepository) 
                => this.medicalRecordRepository = medicalRecordRepository;

            public async Task<Result> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
                => await this.medicalRecordRepository.Delete(request.Id, cancellationToken);
        }
    }
}
