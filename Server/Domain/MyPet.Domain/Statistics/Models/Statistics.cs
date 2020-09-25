namespace MyPet.Domain.Statistics.Models
{
    using MyPet.Domain.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<AdoptionAdView> adoptionAdViews;

        internal Statistics()
        {
            this.TotalAdoptionAds = 0;

            this.adoptionAdViews = new HashSet<AdoptionAdView>();
        }

        public int TotalAdoptionAds { get; private set; }

        public IReadOnlyCollection<AdoptionAdView> AdoptionAdViews
            => this.adoptionAdViews.ToList().AsReadOnly();

        public void AddAdoptionAd()
            => this.TotalAdoptionAds++;

        public void AddAdoptionAdView(int adoptionAdId, string userId)
            => this.adoptionAdViews.Add(new AdoptionAdView(adoptionAdId, userId));
    }
}
