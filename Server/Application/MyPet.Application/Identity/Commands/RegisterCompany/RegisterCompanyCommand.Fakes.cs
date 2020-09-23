namespace MyPet.Application.Identity.Commands.RegisterCompany
{
    using Bogus;

    public class RegisterCompanyCommandFakes
    {
        public static class Data
        {
            public static RegisterCompanyCommand GetCommand()
                => new Faker<RegisterCompanyCommand>()
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Password, f => f.Lorem.Letter(10))
                    .RuleFor(u => u.Name, f => f.Name.FullName())
                    .RuleFor(u => u.OwnerName, f => f.Name.FullName())
                    .RuleFor(u => u.Address, f => f.Lorem.Letter(10))
                    .RuleFor(u => u.LegalityRegistrationNumber, f => f.Lorem.Letter(12))
                    .Generate();
        }
    }
}
