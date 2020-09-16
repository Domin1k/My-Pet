namespace MyPet.Domain.AdoptionAds.Factories
{
    using MyPet.Domain.AdoptionAds.Exceptions;
    using MyPet.Domain.AdoptionAds.Models;

    internal class AdoptionAdFactory : IAdoptionAdFactory
    {
        private AdoptionCategory _adoptionCategory;
        private string _adoptionAdName;
        private string _adoptionAdDescription;
        private string _adoptionPublisherId;

        public IAdoptionAdFactory WithCategory(string name)
            => this.WithCategory(new AdoptionCategory(name));

        public IAdoptionAdFactory WithCategory(AdoptionCategory adoptionCategory)
        {
            _adoptionCategory = adoptionCategory;
            return this;
        }

        public IAdoptionAdFactory WithDescription(string description)
        {
            _adoptionAdDescription = description;
            return this;
        }

        public IAdoptionAdFactory WithName(string name)
        {
            _adoptionAdName = name;
            return this;
        }

        public IAdoptionAdFactory WithPublisherId(string publisherId)
        {
            _adoptionPublisherId = publisherId;
            return this;
        }

        public AdoptionAd Build()
        {
            if (_adoptionCategory == null)
            {
                throw new InvalidAdoptionAdException("AdoptionCategory cannot be null");
            }

            return new AdoptionAd(_adoptionAdName, _adoptionAdDescription, _adoptionPublisherId, _adoptionCategory);
        }
    }
}
