namespace MyPet.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using MyPet.Application.Features.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;
    }
}
