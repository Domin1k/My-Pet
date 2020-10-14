﻿namespace MyPet.Web.Common
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Security.Claims;
    using Application.Contracts;

    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            if (user.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                this.UserId = new Guid(user.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            this.Email = user.FindFirstValue(ClaimTypes.Email);
        }

        public Guid UserId { get; }

        public string Email { get; }
    }
}
