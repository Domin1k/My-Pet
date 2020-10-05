namespace MyPet.Startup.Specs
{
    using FluentAssertions;
    using MyPet.Application.MedicalRecords.Commands.Create;
    using MyPet.Application.MedicalRecords.Commands.CreateTreatment;
    using MyPet.Application.MedicalRecords.Commands.Delete;
    using MyPet.Application.MedicalRecords.Commands.Edit;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Application.MedicalRecords.Queries.Search;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Domain.MedicalRecords.Models;
    using MyPet.Web.MedicalRecords;
    using MyTested.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc.Utilities.Extensions;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class MedicalRecordsControllerSpecs
    {
        private readonly string controllerName = typeof(MedicalRecordsController).Name.Replace("Controller", string.Empty);
        
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 10)]
        public void Details_ShouldReturnDetailsOutputWhenIdExists(int id, int totalTreatments)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/{this.controllerName}/{id}")
                .To<MedicalRecordsController>(c => c.Details(new MedicalRecordDetailsQuery { Id = id }))
                .Which(instance => instance.WithData(MedicalRecordFakes.Data.GetMedicalRecord(id, totalTreatments)))
                .ShouldReturn()
                .ActionResult<MedicalRecordDetailsOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.AnimalAge.Should().BeGreaterThan(0);
                        model.AnimalName.Should().NotBeNullOrEmpty();
                        model.Treatments.Should().HaveCount(totalTreatments);
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
                            AnimalAge = 10,
                            AnimalBreedName = "Pom",
                            AnimalName = "Johny",
                            AnimalSpecies = Species.Dog.ToString()
                        }))
                .To<MedicalRecordsController>(c => c
                    .Create(new CreateMedicalRecordCommand
                    {
                        AnimalAge = 10,
                        AnimalBreedName = "Pom",
                        AnimalName = "Johny",
                        AnimalSpecies = Species.Dog.ToString()
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .ActionResult<CreateMedicalRecordOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.MedicalRecordId.Should().BeGreaterThan(0);
                    }));

        [Theory]
        [InlineData(1)]
        public void CreateTreatment_WithValidData_ShouldReturnIdOfCreatedRecord(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}/{id}/treatment")
                        .WithMethod(HttpMethod.Post)
                        .WithJsonBody(new
                        {
                            Description = "newDescription",
                            ImageUrl = "http://someimage.com",
                            Title = "MyTitle",
                        }))
                .To<MedicalRecordsController>(c => c
                    .Treatment(id, new CreateTreatmentCommand
                    {
                       Description = "newDescription",
                       ImageUrl = "http://someimage.com",
                       Title = "MyTitle",
                    }))
                .Which(instance => instance.WithData(MedicalRecordFakes.Data.GetMedicalRecord()))
                .ShouldReturn()
                .ActionResult<CreateTreatmentOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.MedicalRecordId.Should().Be(id);
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
                            AnimalAge = 10,
                            AnimalBreedName = "MyBreed",
                            AnimalName = "Johny",
                            AnimalSpecies = Species.Dog.ToString()
                        }))
                .To<MedicalRecordsController>(c => c
                    .Edit(id, new EditMedicalRecordCommand
                    {
                        AnimalAge = 10,
                        AnimalBreedName = "MyBreed",
                        AnimalName = "Johny",
                        AnimalSpecies = Species.Dog.ToString()
                    }))
                .Which(instance => instance.WithData(MedicalRecordFakes.Data.GetMedicalRecord(id)))
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
                .To<MedicalRecordsController>(c => c
                    .Delete(new DeleteMedicalRecordCommand
                    {
                        Id = id
                    }))
                .Which(instance => instance.WithData(MedicalRecordFakes.Data.GetMedicalRecord(id)))
                .ShouldReturn()
                .Ok();

        [Theory]
        [InlineData("AnimalName", 2)]
        public void Search_ShouldReturnAllMedicalRecordsWhereCriteriaMatches(string animalName, int page)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/{this.controllerName}?{nameof(animalName)}={animalName}&{nameof(page)}={page}&sortby=animalName")
                .To<MedicalRecordsController>(c => c.Search(new MedicalRecordSearchQuery { AnimalName = animalName, Page = page, SortBy = "animalName" }))
                .Which(instance => instance.WithData(MedicalRecordFakes.Data.GetMedicalRecords(3)))
                .ShouldReturn()
                .ActionResult<List<MedicalRecordSearchOutputModel>>(result => result
                    .Passing(model =>
                    {
                        model.Count().Should().Equals(10);
                        model.First().AnimalName.Should().Equals($"{animalName}11");
                        model.Last().AnimalName.Should().Equals($"{animalName}20");
                        model.All(m => m.AnimalName.StartsWith(animalName)).Should().BeTrue();
                    }));
    }
}
