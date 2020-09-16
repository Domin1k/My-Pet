namespace MyPet.Domain.AdoptionAds.Factories
{
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common.Factories;

    public interface IAdoptionAdFactory : IFactory<AdoptionAd>
    {
        IAdoptionAdFactory WithPublisherId(string publisherId);

        IAdoptionAdFactory WithName(string name);

        IAdoptionAdFactory WithDescription(string description);

        IAdoptionAdFactory WithCategory(string name);

        IAdoptionAdFactory WithCategory(AdoptionCategory adoptionCategory);
    }
}
