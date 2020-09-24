namespace MyPet.Application.MedicalRecords.Commands.Common
{
    using FluentValidation;
    using MyPet.Domain.Common.Models;
    using MyPet.Domain.MedicalRecords.Models;

    public class MedicalRecordCommandValidator : AbstractValidator<MedicalRecordInputModel>
    {
        public MedicalRecordCommandValidator()
        {
            this.RuleFor(x => x.AnimalAge)
                .GreaterThan(MedicalRecordConstants.MedicalRecord.MinAge)
                .LessThanOrEqualTo(MedicalRecordConstants.MedicalRecord.MaxAge)
                .NotEmpty();

            this.RuleFor(x => x.AnimalBreedName)
                .MinimumLength(MedicalRecordConstants.MedicalRecord.MinBreedLength)
                .MaximumLength(MedicalRecordConstants.MedicalRecord.MaxBreedLength);

            this.RuleFor(x => x.AnimalName)
                .MinimumLength(ModelConstants.Common.MinNameLength)
                .MaximumLength(ModelConstants.Common.MaxNameLength)
                .NotEmpty();

            this.RuleFor(x => x.AnimalSpecies)
                .Must(a => Enumeration.HasValue<Species>(Enumeration.FromName<Species>(a).Value))
                .WithMessage("'Animal Species' is not valid")
                .NotEmpty();
        }
    }
}
