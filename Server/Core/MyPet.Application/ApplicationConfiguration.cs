namespace MyPet.Application
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using Behaviors;
    using Contracts;
    using Mapping;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<AppSettings>(
                    configuration.GetSection(nameof(AppSettings)),
                    options => options.BindNonPublicProperties = true)
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddEventHandlers()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        private static IServiceCollection AddEventHandlers(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
