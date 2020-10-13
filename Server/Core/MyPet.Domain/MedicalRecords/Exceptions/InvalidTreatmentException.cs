namespace MyPet.Domain.MedicalRecords.Exceptions
{
    using Domain.Exceptions;

    public class InvalidTreatmentException : BaseDomainException
    {
        public InvalidTreatmentException()
        {
        }

        public InvalidTreatmentException(string error)
            => this.Error = error;
    }
}
