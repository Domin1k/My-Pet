namespace MyPet.Application.MedicalRecords.Commands.Edit
{
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Application.MedicalRecords.Commands.Common;
    using MyPet.Domain.MedicalRecords;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditMedicalRecordCommand : MedicalRecordInputModel, IRequest<Result>
    {
        public class EditMedicalRecordCommandHandler : IRequestHandler<EditMedicalRecordCommand, Result>
        {
            private readonly IMedicalRecordDomainRepository medicalRecordRepository;

            public EditMedicalRecordCommandHandler(IMedicalRecordDomainRepository medicalRecordRepository) 
                => this.medicalRecordRepository = medicalRecordRepository;

            public async Task<Result> Handle(EditMedicalRecordCommand request, CancellationToken cancellationToken)
            {
                var medicalRecord = await this.medicalRecordRepository.Find(request.Id, cancellationToken);

                medicalRecord
                    .UpdateAnimalAge(request.AnimalAge)
                    .UpdateAnimalName(request.AnimalName)
                    .UpdateAnimalSpeciesAndBreed(request.AnimalBreedName, request.AnimalSpecies);

                await this.medicalRecordRepository.Save(medicalRecord, cancellationToken);

                return Result.Success;
            }
        }
    }
}
