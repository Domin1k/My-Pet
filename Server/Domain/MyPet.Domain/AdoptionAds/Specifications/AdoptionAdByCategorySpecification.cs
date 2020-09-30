namespace MyPet.Domain.AdoptionAds.Specifications
{
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class AdoptionAdByCategorySpecification : Specification<AdoptionAd>
    {
        private readonly string categoryName;

        public AdoptionAdByCategorySpecification(string categoryName)
            => this.categoryName = categoryName;

        protected override bool Include => !string.IsNullOrEmpty(this.categoryName);

        public override Expression<Func<AdoptionAd, bool>> ToExpression()
            => adoptionAd => adoptionAd.Category.Name == this.categoryName;
    }
}
