﻿namespace MyPet.Infrastructure.Identity
{
    using FakeItEasy;
    using Microsoft.AspNetCore.Identity;

    public class IdentityFakes
    {
        public const string TestEmail = "test@test.com";
        public const string ValidPassword = "TestPass";

        public static UserManager<ApplicationUser> FakeUserManager
        {
            get
            {
                var userManager = A.Fake<UserManager<ApplicationUser>>();

                A.CallTo(() => userManager.FindByEmailAsync(TestEmail)).Returns(new ApplicationUser(TestEmail) { Id = "test" });

                A
                    .CallTo(() => userManager.CheckPasswordAsync(A<ApplicationUser>.That.Matches(u => u.Email == TestEmail), ValidPassword))
                    .Returns(true);

                return userManager;
            }
        }
    }
}
