namespace MyPet.Web
{
    using Application;
    using Application.Contracts;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Web.Common;

    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation.RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
