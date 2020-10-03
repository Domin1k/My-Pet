namespace MyPet.Web.Common
{
    using FakeItEasy;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.CompanyUsers.Models;

    public class CurrentUserServiceFakes
    {
        public static ICurrentUserService FakeCurrentUserService
        {
            get
            {
                var currentUserService = A.Fake<ICurrentUserService>();

                A
                    .CallTo(() => currentUserService.UserId)
                    .Returns(CompanyUserFakes.CompanyUserFakeApplicationId);

                A
                    .CallTo(() => currentUserService.Email)
                    .Returns(CompanyUserFakes.CompanyUserFakeEmailAddress);

                return currentUserService;
            }
        }
    }
}
