namespace MyPet.Domain.AdoptionAds.Models
{
    using MyPet.Domain.AdoptionAds.Exceptions;
    using MyPet.Domain.Common.Models;

    public class AdoptionCategory : AuditableEntity<int>
    {
        internal AdoptionCategory(string name)
        {
            this.Validate(name);

            Name = name;
        }

        public string Name { get; }

        public void Validate(string name)
            => Guard.ForStringLength<InvalidAdoptionCategoryException>(
                name,
                AdoptionConstants.AdoptionCategory.MinAdoptionCategoryNameLength,
                AdoptionConstants.AdoptionCategory.MaxAdoptionCategoryNameLength,
                nameof(this.Name));
    }
}
