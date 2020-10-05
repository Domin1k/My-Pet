namespace MyPet.Web.Identity
{
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.Identity.Commands.Login;
    using MyPet.Application.Identity.Commands.Register;
    using MyPet.Web.Common;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterCommand command)
        => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginCommand command)
           => await this.Send(command);
    }
}
