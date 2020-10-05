namespace MyPet.Infrastructure
{
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Application.AdoptionAds;
    using MyPet.Application.Common.Mapping;
    using MyPet.Application.CompanyUsers;
    using MyPet.Application.MedicalRecords;
    using MyPet.Infrastructure.AdoptionAds;
    using MyPet.Infrastructure.CompanyUsers;
    using MyPet.Infrastructure.MedicalRecords;
    using MyPet.Infrastructure.Persistence;
    using System;
    using System.Reflection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositories_ShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<MyPetDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<ICompanyUsersDbContext>(provider => provider.GetService<MyPetDbContext>())
                .AddScoped<IAdoptionAdsDbContext>(provider => provider.GetService<MyPetDbContext>())
                .AddScoped<IMedicalRecordsDbContext>(provider => provider.GetService<MyPetDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly())), Array.Empty<Assembly>())
                .AddQueryRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICompanyUserQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMedicalRecordQueryRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IAdoptionAdQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
