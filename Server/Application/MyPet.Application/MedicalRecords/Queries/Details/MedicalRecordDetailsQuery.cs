﻿namespace MyPet.Application.MedicalRecords.Queries.Details
{
    using MediatR;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class MedicalRecordDetailsQuery : EntityCommand<int>, IRequest<MedicalRecordDetailsOutputModel>
    {
        public class MedicalRecordDetailsQueryHandler : IRequestHandler<MedicalRecordDetailsQuery, MedicalRecordDetailsOutputModel>
        {
            private readonly IMedicalRecordRepository medicalRecordRepository;

            public MedicalRecordDetailsQueryHandler(IMedicalRecordRepository medicalRecordRepository)
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
