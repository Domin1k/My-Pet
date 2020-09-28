namespace MyPet.Startup.Specs
{
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
                .ShouldMap($"/{this.controllerName}/{CompanyUserFakes.CompanyUserFakeApplicationId}")
                .To<CompanyUsersController>(c => c.Profile(new CompanyUserProfileQuery { Id = CompanyUserFakes.CompanyUserFakeApplicationId }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .ActionResult<CompanyUserProfileOutputModel>(result => result
                    .Passing(model =>
                    {
                        // TODO
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
                            // TODO
                        }))
                .To<CompanyUsersController>(c => c
                    .Edit(id, new EditCompanyUserCommand
                    {
                        // TODO
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .Ok();

        [Fact]
        public void Delete_ForExistingRecord_ShouldCorrectlyDeleteRecord()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                        .WithLocation($"/{this.controllerName}/{CompanyUserFakes.CompanyUserFakeApplicationId}")
                        .WithMethod(HttpMethod.Delete))
                .To<CompanyUsersController>(c => c
                    .Delete(new DeleteCompanyUserCommand
                    {
                        Id = CompanyUserFakes.CompanyUserFakeApplicationId
                    }))
                .Which(instance => instance.WithData(CompanyUserFakes.Data.GetCompanyUser()))
                .ShouldReturn()
                .Ok();
    }
}
