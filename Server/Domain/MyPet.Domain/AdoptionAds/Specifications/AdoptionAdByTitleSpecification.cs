namespace MyPet.Domain.AdoptionAds.Specifications
{
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Domain.Common;
    using System;
    using System.Linq.Expressions;

    public class AdoptionAdByTitleSpecification : Specification<AdoptionAd>
    {
        private readonly string title;

        public AdoptionAdByTitleSpecification(string title)
            => this.title = title;

        protected override bool Include => !string.IsNullOrEmpty(this.title);

        public override Expression<Func<AdoptionAd, bool>> ToExpression()
            => adoptionAd => adoptionAd.Title == this.title;
    }
}
