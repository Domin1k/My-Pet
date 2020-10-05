namespace MyPet.Domain.AdoptionAds.Exceptions
{
    using MyPet.Domain.Common.Exceptions;

    public class InvalidAdoptionAdException : BaseDomainException
    {
        public InvalidAdoptionAdException()
        {
        }

        public InvalidAdoptionAdException(string error)
            => this.Error = error;
    }
}
