namespace MyPet.Domain.MedicalRecords.Exceptions
{
    using MyPet.Domain.Common.Exceptions;

    public class InvalidMedicalRecordException : BaseDomainException
    {
        public InvalidMedicalRecordException()
        {
        }

        public InvalidMedicalRecordException(string error) 
            => this.Error = error;
    }
}
