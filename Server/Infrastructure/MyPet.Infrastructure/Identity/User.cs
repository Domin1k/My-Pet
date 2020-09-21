namespace MyPet.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyPet.Application.Identity.Contracts;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;
    }
}
