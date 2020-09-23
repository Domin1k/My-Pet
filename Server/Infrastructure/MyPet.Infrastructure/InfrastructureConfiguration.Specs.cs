namespace MyPet.Infrastructure
{
    using AutoMapper;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Application.AdoptionAds;
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
                .AddTransient(_ => A.Fake<ICompanyUsersDbContext>())
                .AddTransient(_ => A.Fake<IAdoptionAdsDbContext>())
                .AddTransient(_ => A.Fake<IMedicalRecordsDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICompanyUserRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IMedicalRecordRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IAdoptionAdRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
