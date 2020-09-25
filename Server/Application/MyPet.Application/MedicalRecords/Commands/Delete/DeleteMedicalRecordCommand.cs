﻿namespace MyPet.Application.MedicalRecords.Commands.Delete
{
    using MediatR;
    using MyPet.Application.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMedicalRecordCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteMedicalRecordCommandHandler : IRequestHandler<DeleteMedicalRecordCommand, Result>
        {
            private readonly IMedicalRecordRepository medicalRecordRepository;

            public DeleteMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository) 
                => this.medicalRecordRepository = medicalRecordRepository;

            public async Task<Result> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
                => await this.medicalRecordRepository.Delete(request.Id, cancellationToken);
        }
    }
}
