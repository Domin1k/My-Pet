namespace MyPet.Startup.Specs
{
    using Application.Identity.Commands.LoginCompany;
    using FluentAssertions;
    using MyPet.Application.Identity.Commands.RegisterCompany;
    using MyPet.Infrastructure.Identity;
    using MyPet.Web.Identity;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void RegisterCompany_ShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .RegisterCompany(RegisterCompanyCommandFakes.Data.GetCommand()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.RegisterCompany)));

        [Theory]
        [InlineData(IdentityFakes.TestEmail, IdentityFakes.ValidPassword)]
        public void LoginCompany_ShouldHaveCorrectAttributes(string email, string password)
            => MyController<IdentityController>
                .Calling(c => c
                    .LoginCompany(new LoginCompanyCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.LoginCompany)));

        [Theory]
        [InlineData(IdentityFakes.TestEmail, IdentityFakes.ValidPassword, JwtTokenGeneratorFakes.ValidToken)]
        public void LoginCompany_ShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation("/Identity/LoginCompany")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new
                    {
                        Email = email,
                        Password = password
                    }))
                .To<IdentityController>(c => c
                    .LoginCompany(new LoginCompanyCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .Which()
                .ShouldReturn()
                .ActionResult<LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
    }
}
