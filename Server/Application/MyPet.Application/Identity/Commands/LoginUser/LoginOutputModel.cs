namespace MyPet.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int dealerId)
        {
            Token = token;
            DealerId = dealerId;
        }

        public int DealerId { get; }

        public string Token { get; }
    }
}
