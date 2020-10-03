namespace MyPet.Application.MedicalRecords.Commands.CreateTreatment
{
    using FluentValidation;
    using MediatR;
    using MyPet.Application.Common;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords;
    using MyPet.Domain.MedicalRecords.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTreatmentCommand : EntityCommand<int>, IRequest<CreateTreatmentOutputModel>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? Next { get; set; }

        public class CreateTreatmentCommandHandler : IRequestHandler<CreateTreatmentCommand, CreateTreatmentOutputModel>
        {
            private readonly IMedicalRecordDomainRepository medicalRecordDomainRepository;

            public CreateTreatmentCommandHandler(IMedicalRecordDomainRepository medicalRecordDomainRepository) 
                => this.medicalRecordDomainRepository = medicalRecordDomainRepository;

            public async Task<CreateTreatmentOutputModel> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
            {
                var medicalRecord = await this.medicalRecordDomainRepository.Find(request.Id, cancellationToken);
                medicalRecord.AddTreatment(
                        request.Title,
                        request.Description,
                        request.ImageUrl,
                        request.Next);
                await this.medicalRecordDomainRepository.Save(medicalRecord, cancellationToken);

                return new CreateTreatmentOutputModel(medicalRecord.Id);
            }
        }

        public class CreateTreatmentCommandValidator : AbstractValidator<CreateTreatmentCommand>
        {
            public CreateTreatmentCommandValidator()
            {
                this.RuleFor(x => x.Title)
                    .MinimumLength(MedicalRecordConstants.Treatment.MinTreatmentTitleLength)
                    .MaximumLength(MedicalRecordConstants.Treatment.MaxTreatmentTitleLength)
                    .NotEmpty();

                this.RuleFor(x => x.Description)
                    .MinimumLength(ModelConstants.Common.Zero)
                    .MaximumLength(MedicalRecordConstants.Treatment.MaxTreatmentDescriptionLength)
                    .NotEmpty();

                this.RuleFor(x => x.ImageUrl)
                    .Must(LinkMustBeAUri);

                this.RuleFor(x => x.Next)
                    .Must(BeFutureDate);
            }

            private bool BeFutureDate(DateTime? arg)
            {
                if (!arg.HasValue)
                {
                    return true;
                }

                return arg.Value < DateTime.UtcNow;
            }

            private bool LinkMustBeAUri(string link)
            {
                if (string.IsNullOrWhiteSpace(link))
                {
                    return false;
                }

                return Uri.TryCreate(link, UriKind.Absolute, out var outUri) 
                    && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
            }
        }
    }
}
