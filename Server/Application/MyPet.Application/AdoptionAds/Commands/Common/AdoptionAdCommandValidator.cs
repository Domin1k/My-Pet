namespace MyPet.Application.AdoptionAds.Commands.Common
{
    using FluentValidation;
    using MyPet.Domain.AdoptionAds.Models;

    public class AdoptionAdCommandValidator : AbstractValidator<AdoptionAdInputModel>
    {
        public AdoptionAdCommandValidator()
        {
            this.RuleFor(x => x.CategoryName)
                .MinimumLength(AdoptionConstants.AdoptionCategory.MinAdoptionCategoryNameLength)
                .MaximumLength(AdoptionConstants.AdoptionCategory.MaxAdoptionCategoryNameLength)
                .NotEmpty();

            this.RuleFor(x => x.Description)
                .MinimumLength(AdoptionConstants.AdoptionAd.MinAdoptionAdDescriptionLength)
                .MaximumLength(AdoptionConstants.AdoptionAd.MaxAdoptionAdDescriptionLength)
                .NotEmpty();

            this.RuleFor(x => x.PublisherId)
                .NotNull()
                .NotEmpty()
                .WithMessage("'PublisherId' must be populated");

            this.RuleFor(x => x.Title)
                .MinimumLength(AdoptionConstants.AdoptionAd.MinAdoptionAdTitleLength)
                .MaximumLength(AdoptionConstants.AdoptionAd.MaxAdoptionAdTitleLength)
                .NotEmpty();
        }
    }
}
