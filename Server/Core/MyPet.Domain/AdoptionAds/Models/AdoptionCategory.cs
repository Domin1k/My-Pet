namespace MyPet.Domain.AdoptionAds.Models
{
    using Domain.Models;
    using MyPet.Domain.AdoptionAds.Exceptions;

    public class AdoptionCategory : Entity<int>
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
