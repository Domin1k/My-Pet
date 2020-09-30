namespace MyPet.Web.CompanyUsers
{
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.Common;
    using MyPet.Application.CompanyUsers.Commands.Delete;
    using MyPet.Application.CompanyUsers.Commands.Edit;
    using MyPet.Application.CompanyUsers.Queries.Profile;
    using MyPet.Web.Common;
    using System.Threading.Tasks;

    public class CompanyUsersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CompanyUserProfileOutputModel>> Profile([FromRoute] CompanyUserProfileQuery query)
               => await this.Send(query);

        [HttpPut]
        public async Task<ActionResult> Edit(EditCompanyUserCommand command)
            => await this.Send(command);

        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] DeleteCompanyUserCommand command)
            => await this.Send(command);
    }
}
