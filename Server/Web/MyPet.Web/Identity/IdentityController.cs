﻿namespace MyPet.Web.Identity
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Application.Identity.Commands.ChangePassword;
    using MyPet.Application.Identity.Commands.LoginCompany;
    using MyPet.Application.Identity.Commands.RegisterCompany;
    using MyPet.Web.Common;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(RegisterCompany))]
        public async Task<ActionResult> RegisterCompany(RegisterCompanyCommand command)
        => await this.Send(command);

        [HttpPost]
        [Route(nameof(LoginCompany))]
        public async Task<ActionResult<LoginOutputModel>> LoginCompany(LoginCompanyCommand command)
           => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
            => await this.Send(command);
    }
}