namespace MyPet.Application.MedicalRecords.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class MedicalRecordDetailsQuery : EntityCommand<int>, IRequest<MedicalRecordDetailsOutputModel>
    {
        public class MedicalRecordDetailsQueryHandler : IRequestHandler<MedicalRecordDetailsQuery, MedicalRecordDetailsOutputModel>
        {
            private readonly IMedicalRecordQueryRepository medicalRecordRepository;

            public MedicalRecordDetailsQueryHandler(IMedicalRecordQueryRepository medicalRecordRepository)
            {
                this.medicalRecordRepository = medicalRecordRepository;
            }

            public async Task<MedicalRecordDetailsOutputModel> Handle(MedicalRecordDetailsQuery request, CancellationToken cancellationToken)
            {
                var data = await this.medicalRecordRepository.GetDetails(request.Id, cancellationToken);
                return data;
            }
        }
    }
}
