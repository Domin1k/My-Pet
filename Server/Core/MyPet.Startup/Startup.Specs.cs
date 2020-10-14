namespace MyPet.Startup
{
    using Application.Contracts;
    using Infrastructure.Identity;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Application.AdoptionAds;
    using MyPet.Application.CompanyUsers;
    using MyPet.Application.MedicalRecords;
    using MyPet.Web.Common;
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
            services.ReplaceTransient<ICurrentUserService>(_ => CurrentUserServiceFakes.FakeCurrentUserService);
        }

        private static void ValidateServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<ICompanyUserQueryRepository>();
            provider.GetRequiredService<IAdoptionAdQueryRepository>();
            provider.GetRequiredService<IMedicalRecordQueryRepository>();
            provider.GetRequiredService<IMediator>();
            provider.GetRequiredService<IControllerFactory>();
        }
    }
}
