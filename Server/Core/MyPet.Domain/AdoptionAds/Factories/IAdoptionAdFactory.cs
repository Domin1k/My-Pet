namespace MyPet.Domain.AdoptionAds.Factories
{
    using Domain.Factories;
    using MyPet.Domain.AdoptionAds.Models;

    public interface IAdoptionAdFactory : IFactory<AdoptionAd>
    {
        IAdoptionAdFactory WithPublisherId(string publisherId);

        IAdoptionAdFactory WithTitle(string title);

        IAdoptionAdFactory WithDescription(string description);

        IAdoptionAdFactory WithCategory(string name);

        IAdoptionAdFactory WithCategory(AdoptionCategory adoptionCategory);
    }
}
