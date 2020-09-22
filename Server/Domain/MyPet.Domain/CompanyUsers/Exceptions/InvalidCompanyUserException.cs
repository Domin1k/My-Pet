namespace MyPet.Domain.CompanyUsers.Exceptions
{
    using MyPet.Domain.Common.Exceptions;

    public class InvalidCompanyUserException : BaseDomainException
    {
        public InvalidCompanyUserException()
        {
        }

        public InvalidCompanyUserException(string error) => Error = error;
    }
}
