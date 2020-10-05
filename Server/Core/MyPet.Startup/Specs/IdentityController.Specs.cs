namespace MyPet.Startup.Specs
{
    using Application.Identity.Commands.Login;
    using FluentAssertions;
    using MyPet.Application.Identity.Commands.Register;
    using MyPet.Infrastructure.Identity;
    using MyPet.Web.Identity;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void Register_ShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Register(RegisterCommandFakes.Data.GetCommand()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Register)));

        [Theory]
        [InlineData(IdentityFakes.TestEmail, IdentityFakes.ValidPassword)]
        public void Login_ShouldHaveCorrectAttributes(string email, string password)
            => MyController<IdentityController>
                .Calling(c => c
                    .Login(new LoginCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Login)));

        [Theory]
        [InlineData(IdentityFakes.TestEmail, IdentityFakes.ValidPassword, JwtTokenGeneratorFakes.ValidToken)]
        public void Login_ShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation("/Identity/Login")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new
                    {
                        Email = email,
                        Password = password
                    }))
                .To<IdentityController>(c => c
                    .Login(new LoginCommand
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
