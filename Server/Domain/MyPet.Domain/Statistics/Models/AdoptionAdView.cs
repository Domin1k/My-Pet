namespace MyPet.Domain.Statistics.Models
{
    using MyPet.Domain.Common.Models;

    public class AdoptionAdView : Entity<int>
    {
        internal AdoptionAdView(int adoptionAdId, string userId)
        {
            AdoptionAdId = adoptionAdId;
            UserId = userId;
        }

        public int AdoptionAdId { get; }

        public string UserId { get; }
    }
}
