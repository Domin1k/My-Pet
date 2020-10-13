namespace MyPet.Application.MedicalRecords.Commands.Create
{
    using MediatR;
    using MyPet.Application.Common.Contracts;
    using MyPet.Application.MedicalRecords.Commands.Common;
    using MyPet.Domain.CompanyUsers;
    using MyPet.Domain.MedicalRecords;
    using MyPet.Domain.MedicalRecords.Factories;
    using MyPet.Domain.MedicalRecords.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;

    public class CreateMedicalRecordCommand : MedicalRecordInputModel, IRequest<CreateMedicalRecordOutputModel>
    {
        public class CreateMedicalRecordCommandHandler : IRequestHandler<CreateMedicalRecordCommand, CreateMedicalRecordOutputModel>
        {
            private readonly IMedicalRecordDomainRepository medicalRecordRepository;
            private readonly IMedicalRecordFactory medicalRecordFactory;
            private readonly ICurrentUserService currentUser;
            private readonly ICompanyUserDomainRepository companyUserRepository;

            public CreateMedicalRecordCommandHandler(
                IMedicalRecordDomainRepository medicalRecordRepository,
                IMedicalRecordFactory medicalRecordFactory,
                ICurrentUserService currentUser,
                ICompanyUserDomainRepository companyUserRepository)
            {
                this.medicalRecordFactory = medicalRecordFactory;
                this.medicalRecordRepository = medicalRecordRepository;
                this.currentUser = currentUser;
                this.companyUserRepository = companyUserRepository;
            }

            public async Task<CreateMedicalRecordOutputModel> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
            {
                var companyUser = await this.companyUserRepository.FindBy(this.currentUser.UserId, cancellationToken);

                var medicalRecord = this.medicalRecordFactory
                        .WithAnimalAge(request.AnimalAge)
                        .WithAnimalName(request.AnimalName)
                        .WithBreed(request.AnimalBreedName, Enumeration.FromName<Species>(request.AnimalSpecies))
                        .Build();
                
                companyUser.AddMedicalRecord(medicalRecord.Id);

                await this.medicalRecordRepository.Save(medicalRecord, cancellationToken);

                return new CreateMedicalRecordOutputModel(medicalRecord.Id);
            }
        }
    }
}
