namespace MyPet.Domain.AdoptionAds.Exceptions
{
    using Domain.Exceptions;

    public class InvalidAdoptionCategoryException : BaseDomainException
    {
        public InvalidAdoptionCategoryException()
        {
        }

        public InvalidAdoptionCategoryException(string error)
            => this.Error = error;
    }
}
