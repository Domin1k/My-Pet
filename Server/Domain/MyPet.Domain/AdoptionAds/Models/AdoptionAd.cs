namespace MyPet.Domain.AdoptionAds.Models
{
    using MyPet.Domain.AdoptionAds.Exceptions;
    using MyPet.Domain.Common.Models;

    public class AdoptionAd : AuditableEntity<int>, IAggregateRoot
    {
        internal AdoptionAd(string name, string description, string publisherId, AdoptionCategory category)
        {
            this.Validate(name, description, publisherId);

            Name = name;
            Description = description;
            Category = category;
            PublisherId = publisherId;
        }

        public string Name { get; }

        public string Description { get; }

        public string PublisherId { get; }

        public AdoptionCategory Category { get; }

        public void Validate(string name, string description, string publisherId)
        {
            Guard.ForStringLength<InvalidAdoptionAdException>(
                name,
                AdoptionConstants.AdoptionAd.MinAdoptionAdNameLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidAdoptionAdException>(
                description,
                AdoptionConstants.AdoptionAd.MinAdoptionAdDescriptionLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdDescriptionLength,
                nameof(this.Description));

            Guard.ForValidGuid<InvalidAdoptionAdException>(publisherId, nameof(this.PublisherId));
        }
    }
}
