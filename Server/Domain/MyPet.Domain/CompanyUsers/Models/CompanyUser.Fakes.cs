namespace MyPet.Domain.CompanyUsers.Models
{
    using Bogus;
    using MyPet.Domain.Common.Models;
    using System;

    public class CompanyUserFakes
    {
        public static Guid CompanyUserFakeApplicationId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");

        public static class Data
        {
            public static CompanyUser GetCompanyUser()
            {
                var companyUser = new Faker<CompanyUser>()
                    .CustomInstantiator(f => new CompanyUser(
                        CompanyUserFakeApplicationId,
                        f.Company.CompanyName(),
                        f.Name.FullName(),
                        f.Address.FullAddress(),
                        "12346"))
                    .Generate()
                    .SetId(CompanyUserFakeApplicationId);

                return companyUser;
            }
        }
    }
}
