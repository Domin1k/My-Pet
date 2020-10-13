namespace MyPet.Domain.AdoptionAds.Models
{
    using Domain.Models;
    using MyPet.Domain.AdoptionAds.Exceptions;

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

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string PublisherId { get; private set; }

        public AdoptionCategory Category { get; private set; }

        public AdoptionAd UpdateTitle(string title)
        {
            this.ValidateTitle(title);
            this.Title = title;
            return this;
        }

        public AdoptionAd UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;
            return this;
        }

        public AdoptionAd UpdateCategory(string categoryName)
        {
            this.Category = new AdoptionCategory(categoryName);
            return this;
        }

        public void Validate(string name, string description, string publisherId)
        {
            this.ValidateTitle(name);
            this.ValidateDescription(description);

            Guard.ForValidGuid<InvalidAdoptionAdException>(publisherId, nameof(this.PublisherId));
        }

        public void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidAdoptionAdException>(
                description,
                AdoptionConstants.AdoptionAd.MinAdoptionAdDescriptionLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdDescriptionLength,
                nameof(this.Description));

        public void ValidateTitle(string name)
            => Guard.ForStringLength<InvalidAdoptionAdException>(
                name,
                AdoptionConstants.AdoptionAd.MinAdoptionAdTitleLength,
                AdoptionConstants.AdoptionAd.MaxAdoptionAdTitleLength,
                nameof(this.Title));
    }
}
