namespace MyPet.Startup.Specs
{
    using FluentAssertions;
    using MyPet.Application.AdoptionAds.Commands.Create;
    using MyPet.Application.AdoptionAds.Commands.Delete;
    using MyPet.Application.AdoptionAds.Commands.Edit;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Domain.AdoptionAds.Models;
    using MyPet.Web.AdoptionAds;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using System;

    public class AdoptionAdsControllerSpecs
    {
        private readonly string controllerName = typeof(AdoptionAdsController).Name.Replace("Controller", string.Empty);
        private readonly string rndPublisherId = Guid.NewGuid().ToString();

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Details_ShouldReturnDetailsOutputWhenIdExists(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/{this.controllerName}/{id}")
                .To<AdoptionAdsController>(c => c.Details(new AdoptionAdDetailsQuery { Id = id }))
                .Which(instance => instance.WithData(AdoptionAdFakes.Data.GetAdoptionAd(id)))
                .ShouldReturn()
                .ActionResult<AdoptionAdDetailsOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.CategoryName.Should().NotBeNullOrEmpty();
                        model.PublisherId.Should().NotBeNullOrEmpty();
                        model.Title.Should().NotBeNullOrEmpty();
                        model.Description.Should().NotBeNullOrEmpty();
                    }));

        [Fact]
        public void Create_WithValidData_ShouldReturnIdOfCreatedRecord()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}")
                        .WithMethod(HttpMethod.Post)
                        .WithJsonBody(new
                        {
                            PublisherId = rndPublisherId,
                            CategoryName = "MyCategory",
                            Description = "MyDesc",
                            Title = "MyTitle"
                        }))
                .To<AdoptionAdsController>(c => c
                    .Create(new CreateAdoptionAdCommand
                    {
                        PublisherId = rndPublisherId,
                        CategoryName = "MyCategory",
                        Description = "MyDesc",
                        Title = "MyTitle"
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .ActionResult<CreateAdoptionAdOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.AdoptionAdId.Should().BeGreaterThan(0);
                    }));

        [Theory]
        [InlineData(1)]
        public void Edit_WithValidData_ForExistingRecord_ShouldCorrectlyModifyRecord(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}/{id}")
                        .WithMethod(HttpMethod.Put)
                        .WithJsonBody(new
                        {
                            CategoryName = "MyCategory",
                            Description = "MyDesc",
                            Title = "MyTitle"
                        }))
                .To<AdoptionAdsController>(c => c
                    .Edit(id, new EditAdoptionAdCommand
                    {
                        CategoryName = "MyCategory",
                        Description = "MyDesc",
                        Title = "MyTitle"
                    }))
                .Which(instance => instance.WithData(AdoptionAdFakes.Data.GetAdoptionAd(id)))
                .ShouldReturn()
                .Ok();

        [Theory]
        [InlineData(1)]
        public void Delete_ForExistingRecord_ShouldCorrectlyDeleteRecord(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}/{id}")
                        .WithMethod(HttpMethod.Delete))
                .To<AdoptionAdsController>(c => c
                    .Delete(new DeleteAdoptionAdCommand
                    {
                        Id = id
                    }))
                .Which(instance => instance.WithData(AdoptionAdFakes.Data.GetAdoptionAd(id)))
                .ShouldReturn()
                .Ok();
    }
}
