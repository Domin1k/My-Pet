namespace MyPet.Domain.AdoptionAds.Models
{
    using MyPet.Domain.AdoptionAds.Exceptions;
    using MyPet.Domain.Common.Models;

    public class AdoptionAd : Entity<int>, IAggregateRoot
    {
        internal AdoptionAd(string title, string description, string publisherId, AdoptionCategory category)
        {
            this.Validate(title, description, publisherId);

            this.Title = title;
            this.Description = description;
            this.Category = category;
            this.PublisherId = publisherId;
        }

        private AdoptionAd(string title, string description, string publisherId)
        {
            this.Title = title;
            this.Description = description;
            this.PublisherId = publisherId;
        }

        public string Title { get; }

        public string Description { get; }

        public string PublisherId { get; }

        public AdoptionCategory Category { get; }

        public void Validate(string name, string description, string publisherId)
        {
            Guard.ForStringLength<InvalidAdoptionAdException>(
                name,
                AdoptionConstants.AdoptionAd.MinAdoptionAdTitleLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdTitleLength,
                nameof(this.Title));

            Guard.ForStringLength<InvalidAdoptionAdException>(
                description,
                AdoptionConstants.AdoptionAd.MinAdoptionAdDescriptionLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdDescriptionLength,
                nameof(this.Description));

            Guard.ForValidGuid<InvalidAdoptionAdException>(publisherId, nameof(this.PublisherId));
        }
    }
}
