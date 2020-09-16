namespace MyPet.Domain.MedicalRecords.Exceptions
{
    using MyPet.Domain.Common.Exceptions;

    public class InvalidTreatmentException : BaseDomainException
    {
        public InvalidTreatmentException()
        {
        }

        public InvalidTreatmentException(string error)
            => this.Error = error;
    }
}
