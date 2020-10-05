namespace MyPet.Application.AdoptionAds.Queries.Common
{
    using MyPet.Application.Common;
    using MyPet.Domain.AdoptionAds.Models;
    using System;
    using System.Linq.Expressions;

    public class AdoptionAdSortOrder : SortOrder<AdoptionAd>
    {
        public AdoptionAdSortOrder(string sortBy, string order)
           : base(sortBy, order)
        {
        }

        public override Expression<Func<AdoptionAd, object>> ToExpression()
        {
            if (string.IsNullOrEmpty(this.SortBy))
            {
                return adoptionAd => adoptionAd.Id;
            }
            return this.SortBy switch
            {
                "title" => adoptionAd => adoptionAd.Title,
                "description" => adoptionAd => adoptionAd.Description,
                "categoryName" => adoptionAd => adoptionAd.Category.Name,
                _ => adoptionAd => adoptionAd.Id
            };
        }
    }
}
