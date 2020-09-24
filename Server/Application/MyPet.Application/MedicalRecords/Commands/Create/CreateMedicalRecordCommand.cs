namespace MyPet.Application.MedicalRecords.Commands.Create
{
    using MediatR;
    using MyPet.Application.MedicalRecords.Commands.Common;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Factories;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateMedicalRecordCommand : MedicalRecordInputModel, IRequest<CreateMedicalRecordOutputModel>
    {
        public class CreateMedicalRecordCommandHandler : IRequestHandler<CreateMedicalRecordCommand, CreateMedicalRecordOutputModel>
        {
            private readonly IMedicalRecordRepository medicalRecordRepository;
            private readonly IMedicalRecordFactory medicalRecordFactory;

            public CreateMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository, IMedicalRecordFactory medicalRecordFactory)
            {
                this.medicalRecordFactory = medicalRecordFactory;
                this.medicalRecordRepository = medicalRecordRepository;
            }

            public async Task<CreateMedicalRecordOutputModel> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
            {
                var medicalRecord = this.medicalRecordFactory
                        .WithAnimalAge(request.AnimalAge)
                        .WithAnimalName(request.AnimalName)
                        .WithBreed(request.AnimalBreedName, Enumeration.FromName<Species>(request.AnimalSpecies))
                        .Build();

                await this.medicalRecordRepository.Save(medicalRecord, cancellationToken);

                return new CreateMedicalRecordOutputModel(medicalRecord.Id);
            }
        }
    }
}
