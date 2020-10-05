namespace MyPet.Domain.AdoptionAds.Exceptions
{
    using MyPet.Domain.Common.Exceptions;

    public class InvalidAdoptionCategoryException : BaseDomainException
    {
        public InvalidAdoptionCategoryException()
        {
        }

        public InvalidAdoptionCategoryException(string error)
            => this.Error = error;
    }
}
