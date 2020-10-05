namespace MyPet.Domain.Statistics.Models
{
    using MyPet.Domain.Common.Models;
    using System.Collections.Generic;

    public class Statistics : IAggregateRoot
    {
        private readonly List<AdoptionAdView> adoptionAdViews;

        internal Statistics()
        {
            this.TotalAdoptionAds = 0;

            this.adoptionAdViews = new List<AdoptionAdView>();
        }

        public int TotalAdoptionAds { get; private set; }

        public IReadOnlyCollection<AdoptionAdView> AdoptionAdViews => this.adoptionAdViews.AsReadOnly();

        public void AddAdoptionAd()
            => this.TotalAdoptionAds++;

        public void AddAdoptionAdView(int adoptionAdId, string userId)
            => this.adoptionAdViews.Add(new AdoptionAdView(adoptionAdId, userId));
    }
}
