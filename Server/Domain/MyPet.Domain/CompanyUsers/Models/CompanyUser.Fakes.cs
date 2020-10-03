namespace MyPet.Domain.CompanyUsers.Models
{
    using Bogus;
    using MyPet.Domain.Common.Models;
    using System;

    public class CompanyUserFakes
    {
        public static int CompanyUserFakeId = 1;
        public static Guid CompanyUserFakeApplicationId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
        public static string CompanyUserFakeEmailAddress = "domin1k@mysite.com";

        public static class Data
        {
            public static CompanyUser GetCompanyUser(int? id = null)
            {
                var companyUser = new Faker<CompanyUser>()
                    .CustomInstantiator(f => new CompanyUser(
                        CompanyUserFakeApplicationId,
                        f.Company.CompanyName(),
                        f.Name.FullName(),
                        f.Address.FullAddress(),
                        "12346",
                        "someEmail@mysite.com"))
                    .Generate()
                    .SetId(id ?? CompanyUserFakeId);

                return companyUser;
            }
        }
    }
}
