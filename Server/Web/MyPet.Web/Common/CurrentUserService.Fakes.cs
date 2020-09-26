namespace MyPet.Web.Common
{
    using FakeItEasy;
    using MyPet.Application.Common.Contracts;
    using MyPet.Domain.CompanyUsers.Models;
    using System;

    public class CurrentUserServiceFakes
    {
        public static ICurrentUserService FakeCurrentUserService
        {
            get
            {
                var currentUserService = A.Fake<ICurrentUserService>();

                A.CallTo(() => currentUserService.UserId).Returns(CompanyUserFakes.CompanyUserFakeApplicationId);

                return currentUserService;
            }
        }
    }
}
