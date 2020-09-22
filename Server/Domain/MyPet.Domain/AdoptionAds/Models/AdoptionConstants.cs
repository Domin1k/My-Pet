namespace MyPet.Domain.AdoptionAds.Models
{
    public class AdoptionConstants
    {
        public class AdoptionCategory
        {
            public const int MinAdoptionCategoryNameLength = 2;
            public const int MaxAdoptionCategoryNameLength = 100;
        }

        public class AdoptionAd
        {
            public const int MinAdoptionAdTitleLength = 2;
            public const int MaxAdoptionAdTitleLength = 100;

            public const int MinAdoptionAdDescriptionLength = 1;
            public const int MaxAdoptionAdDescriptionLength = 1000;
        }
    }
}
