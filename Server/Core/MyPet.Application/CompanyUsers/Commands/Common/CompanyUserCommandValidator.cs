﻿namespace MyPet.Application.CompanyUsers.Commands.Common
{
    using Domain.Models;
    using FluentValidation;
    using MyPet.Domain.CompanyUsers.Models;

    public class CompanyUserCommandValidator<TModel> : AbstractValidator<TModel>
        where TModel : CompanyUserInputModel
    {
        public CompanyUserCommandValidator()
        {
            this.RuleFor(x => x.Address)
                .MinimumLength(CompanyUsersConstants.CompanyUser.MinAddressLength)
                .MaximumLength(CompanyUsersConstants.CompanyUser.MaxAddressLength)
                .NotEmpty();

            this.RuleFor(x => x.CompanyName)
                .MinimumLength(ModelConstants.Common.MinNameLength)
                .MaximumLength(ModelConstants.Common.MaxNameLength)
                .NotEmpty();

            this.RuleFor(x => x.OwnerName)
                .MinimumLength(CompanyUsersConstants.CompanyUser.MinOwnerName)
                .MaximumLength(CompanyUsersConstants.CompanyUser.MaxOwnerName)
                .NotEmpty();

            this.RuleFor(x => x.LegalityRegistrationNumber)
                .MinimumLength(CompanyUsersConstants.CompanyUser.MinLegalityRegistrationNumberLength)
                .MaximumLength(CompanyUsersConstants.CompanyUser.MaxLegalityRegistrationNumberLength)
                .NotEmpty();
        }
    }
}
