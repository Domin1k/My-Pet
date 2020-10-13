namespace MyPet.Domain.AdoptionAds.Exceptions
{
    using Domain.Exceptions;

    public class InvalidAdoptionAdException : BaseDomainException
    {
        public InvalidAdoptionAdException()
        {
        }

        public InvalidAdoptionAdException(string error)
            => this.Error = error;
    }
}
