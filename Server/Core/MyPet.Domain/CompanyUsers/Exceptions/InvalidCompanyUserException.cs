namespace MyPet.Domain.CompanyUsers.Exceptions
{
    using Domain.Exceptions;

    public class InvalidCompanyUserException : BaseDomainException
    {
        public InvalidCompanyUserException()
        {
        }

        public InvalidCompanyUserException(string error) => Error = error;
    }
}
