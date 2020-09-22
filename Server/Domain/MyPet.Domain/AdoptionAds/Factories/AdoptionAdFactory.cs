namespace MyPet.Domain.AdoptionAds.Factories
{
    using MyPet.Domain.AdoptionAds.Exceptions;
    using MyPet.Domain.AdoptionAds.Models;

    internal class AdoptionAdFactory : IAdoptionAdFactory
    {
        private AdoptionCategory adoptionCategory;
        private string adoptionAdTitle;
        private string adoptionAdDescription;
        private string adoptionPublisherId;

        public IAdoptionAdFactory WithCategory(string name)
            => this.WithCategory(new AdoptionCategory(name));

        public IAdoptionAdFactory WithCategory(AdoptionCategory adoptionCategory)
        {
            this.adoptionCategory = adoptionCategory;
            return this;
        }

        public IAdoptionAdFactory WithDescription(string description)
        {
            this.adoptionAdDescription = description;
            return this;
        }

        public IAdoptionAdFactory WithTitle(string title)
        {
            this.adoptionAdTitle = title;
            return this;
        }

        public IAdoptionAdFactory WithPublisherId(string publisherId)
        {
            this.adoptionPublisherId = publisherId;
            return this;
        }

        public AdoptionAd Build()
        {
            if (this.adoptionCategory == null)
            {
                throw new InvalidAdoptionAdException("AdoptionCategory cannot be null");
            }

            return new AdoptionAd(this.adoptionAdTitle, this.adoptionAdDescription, this.adoptionPublisherId, this.adoptionCategory);
        }
    }
}
