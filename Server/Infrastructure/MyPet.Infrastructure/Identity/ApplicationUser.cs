namespace MyPet.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyPet.Application.Identity.Contracts;

    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        internal ApplicationUser(string email)
            : base(email)
            => this.Email = email;
    }
}
