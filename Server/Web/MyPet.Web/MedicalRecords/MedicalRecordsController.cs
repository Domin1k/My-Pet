namespace MyPet.Web.MedicalRecords
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.Common;
    using MyPet.Application.MedicalRecords.Commands.Create;
    using MyPet.Application.MedicalRecords.Commands.CreateTreatment;
    using MyPet.Application.MedicalRecords.Commands.Delete;
    using MyPet.Application.MedicalRecords.Commands.Edit;
    using MyPet.Application.MedicalRecords.Queries.Details;
    using MyPet.Application.MedicalRecords.Queries.Search;
    using MyPet.Web.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    public class MedicalRecordsController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MedicalRecordDetailsOutputModel>> Details([FromRoute] MedicalRecordDetailsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Search))]
        public async Task<ActionResult<IEnumerable<MedicalRecordSearchOutputModel>>> Search([FromRoute] MedicalRecordSearchQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditMedicalRecordCommand command)
            => await this.Send(command.SetId(id));

        [HttpPost]
        public async Task<ActionResult<CreateMedicalRecordOutputModel>> Create(CreateMedicalRecordCommand command)
            => await this.Send(command);

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete([FromRoute] DeleteMedicalRecordCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(Id + PathSeparator + nameof(Treatment))]
        public async Task<ActionResult<CreateTreatmentOutputModel>> Treatment(
            [FromRoute]int id,
            [FromBody]CreateTreatmentCommand command)
            => await this.Send(command.SetId(id));
    }
}
