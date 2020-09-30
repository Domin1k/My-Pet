namespace MyPet.Domain.AdoptionAds.Specifications
{
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class AdoptionAdByDescriptionSpecification : Specification<AdoptionAd>
    {
        private readonly string description;

        public AdoptionAdByDescriptionSpecification(string description)
            => this.description = description;

        protected override bool Include => !string.IsNullOrEmpty(this.description);

        public override Expression<Func<AdoptionAd, bool>> ToExpression()
            => adoptionAd => adoptionAd.Description == this.description;
    }
}
