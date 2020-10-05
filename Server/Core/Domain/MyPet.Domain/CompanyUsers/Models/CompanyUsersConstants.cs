namespace MyPet.Domain.CompanyUsers.Models
{
    public class CompanyUsersConstants
    {
        public class CompanyUser
        {
            public const int MinAddressLength = 0;
            public const int MaxAddressLength = 255;

            public const int MinOwnerName = 2;
            public const int MaxOwnerName = 100;

            public const int MinLegalityRegistrationNumberLength = 4;
            public const int MaxLegalityRegistrationNumberLength = 255;
        }
    }
}
