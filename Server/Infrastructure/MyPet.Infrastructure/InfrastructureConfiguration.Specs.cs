namespace MyPet.Infrastructure
{
    using AutoMapper;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPet.Infrastructure.Persistence;
    using System;
    using System.Reflection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<MyPetDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));
                //.AddTransient(_ => A.Fake<IDealershipDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            //// Assert
            //services
            //    .GetService<ICarAdRepository>()
            //    .Should()
            //    .NotBeNull();
        }
    }
}
