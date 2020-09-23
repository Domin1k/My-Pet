namespace MyPet.Startup
{
    using Infrastructure.Identity;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Application.AdoptionAds;
    using MyPet.Application.CompanyUsers;
    using MyPet.Application.MedicalRecords;
    using MyTested.AspNetCore.Mvc;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ValidateServices(services);

            services.ReplaceTransient<UserManager<ApplicationUser>>(_ => IdentityFakes.FakeUserManager);
            services.ReplaceTransient<IJwtTokenGenerator>(_ => JwtTokenGeneratorFakes.FakeJwtTokenGenerator);
        }

        private static void ValidateServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<ICompanyUserRepository>();
            provider.GetRequiredService<IAdoptionAdRepository>();
            provider.GetRequiredService<IMedicalRecordRepository>();
            provider.GetRequiredService<IMediator>();
            provider.GetRequiredService<IControllerFactory>();
        }
    }
}
