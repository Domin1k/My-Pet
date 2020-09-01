namespace MyPet.Domain.Exceptions
{
    public class InvalidMedicalRecordException : BaseDomainException
    {
        public InvalidMedicalRecordException()
        {
        }

        public InvalidMedicalRecordException(string error) 
            => this.Error = error;
    }
}
