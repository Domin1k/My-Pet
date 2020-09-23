namespace MyPet.Web.AdoptionAds
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.AdoptionAds.Commands.Create;
    using MyPet.Application.AdoptionAds.Commands.Delete;
    using MyPet.Application.AdoptionAds.Commands.Edit;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.Common;
    using MyPet.Web.Common;
    using System.Threading.Tasks;

    [Authorize]
    public class AdoptionAdsController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route(Id)]
        public async Task<ActionResult<AdoptionAdDetailsOutputModel>> Details([FromRoute] AdoptionAdDetailsQuery query)
            => await this.Send(query);

        [HttpPut]        
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditAdoptionAdCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete([FromRoute] DeleteAdoptionAdCommand command)
            => await this.Send(command);

        [HttpPost]
        public async Task<ActionResult> Create(CreateAdoptionAdCommand command)
            => await this.Send(command);
    }
}
