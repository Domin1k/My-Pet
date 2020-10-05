namespace MyPet.Startup.Specs
{
    using FluentAssertions;
    using MyPet.Application.CompanyUsers.Commands.Create;
    using MyPet.Application.CompanyUsers.Commands.Delete;
    using MyPet.Application.CompanyUsers.Commands.Edit;
    using MyPet.Application.CompanyUsers.Queries.Profile;
    using MyPet.Domain.CompanyUsers.Models;
    using MyPet.Web.CompanyUsers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CompanyUsersControllerSpecs
    {
        private readonly string controllerName = typeof(CompanyUsersController).Name.Replace("Controller", string.Empty);

        [Fact]
        public void Profile_ShouldReturnDetailsOutputWhenIdExists()
            => MyPipeline
                .Configuration()
                .ShouldMap($"/{this.controllerName}")
                .To<CompanyUsersController>(c => c.Profile(new CompanyUserProfileQuery()))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .ActionResult<CompanyUserProfileOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.Address.Should().NotBeNullOrEmpty();
                        model.OwnerName.Should().NotBeNullOrEmpty();
                        model.ApplicationUserId.Should().NotBeNullOrEmpty();
                        model.CompanyName.Should().NotBeNullOrEmpty();
                        model.LegalityRegistrationNumber.Should().NotBeNullOrEmpty();
                    }));

        [Fact]
        public void Edit_WithValidData_ForExistingRecord_ShouldCorrectlyModifyRecord()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}")
                        .WithMethod(HttpMethod.Put)
                        .WithJsonBody(new
                        {
                            LegalityRegistrationNumber = "321312312",
                            Address = "Bulgaria, Sofia 1000",
                            CompanyName = "MyCompany",
                            OwnerName = "Domin1k",
                            CompanyEmailAddress = CompanyUserFakes.CompanyUserFakeEmailAddress

                        }))
                .To<CompanyUsersController>(c => c
                    .Edit(new EditCompanyUserCommand
                    {
                        LegalityRegistrationNumber = "321312312",
                        Address = "Bulgaria, Sofia 1000",
                        CompanyName = "MyCompany",
                        OwnerName = "Domin1k",
                        CompanyEmailAddress = CompanyUserFakes.CompanyUserFakeEmailAddress
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .Ok();

        [Fact]
        public void Create_WithValidData_ForExistingRecord_ShouldCorrectlyModifyRecord()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}")
                        .WithMethod(HttpMethod.Post)
                        .WithJsonBody(new
                        {
                            LegalityRegistrationNumber = "321312312",
                            Address = "Bulgaria, Sofia 1000",
                            CompanyName = "MyCompany",
                            OwnerName = "Domin1k"
                        }))
                .To<CompanyUsersController>(c => c
                    .Create(new CreateCompanyUserCommand
                    {
                        LegalityRegistrationNumber = "321312312",
                        Address = "Bulgaria, Sofia 1000",
                        CompanyName = "MyCompany",
                        OwnerName = "Domin1k"
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .ActionResult<CreateCompanyUserOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.UserId.Should().Equals(CompanyUserFakes.CompanyUserFakeId);
                    }));

        [Fact]
        public void Delete_ForExistingRecord_ShouldCorrectlyDeleteRecord()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}")
                        .WithMethod(HttpMethod.Delete))
                .To<CompanyUsersController>(c => c
                    .Delete(new DeleteCompanyUserCommand()))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .Ok();
    }
}
