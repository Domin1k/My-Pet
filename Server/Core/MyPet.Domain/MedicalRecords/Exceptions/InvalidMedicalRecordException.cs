namespace MyPet.Domain.MedicalRecords.Exceptions
{
    using Domain.Exceptions;

    public class InvalidMedicalRecordException : BaseDomainException
    {
        public InvalidMedicalRecordException()
        {
        }

        public InvalidMedicalRecordException(string error) 
            => this.Error = error;
    }
}
