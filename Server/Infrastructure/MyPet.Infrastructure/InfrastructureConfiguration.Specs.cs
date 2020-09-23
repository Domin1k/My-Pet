namespace MyPet.Infrastructure
{
    using AutoMapper;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Application.CompanyUsers;
    using MyPet.Infrastructure.CompanyUsers;
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
                .AddTransient(_ => A.Fake<ICompanyUsersDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICompanyUsersRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
