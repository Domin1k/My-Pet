namespace MyPet.Web.AdoptionAds
{
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.AdoptionAds.Commands.Create;
    using MyPet.Application.AdoptionAds.Commands.Delete;
    using MyPet.Application.AdoptionAds.Commands.Edit;
    using MyPet.Application.AdoptionAds.Queries.Details;
    using MyPet.Application.Common;
    using MyPet.Web.Common;
    using System.Threading.Tasks;

    public class AdoptionAdsController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AdoptionAdDetailsOutputModel>> Details([FromRoute] AdoptionAdDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditAdoptionAdCommand command)
            => await this.Send(command.SetId(id));

        [HttpPost]
        public async Task<ActionResult> Create(CreateAdoptionAdCommand command)
            => await this.Send(command);

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteAdoptionAdCommand command)
            => await this.Send(command);
    }
}
