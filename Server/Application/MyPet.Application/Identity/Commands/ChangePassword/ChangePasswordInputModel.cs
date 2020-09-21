namespace MyPet.Application.Identity.Commands.ChangePassword
{
    public class ChangePasswordInputModel
    {
        public ChangePasswordInputModel(
            string userId,
            string currentPassword,
            string newPassword)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

        public string UserId { get; }

        public string CurrentPassword { get; }

        public string NewPassword { get; }
    }
}
