using Framework.Models.Result;

namespace Abstract.Service
{
    public interface IAuthenticationService
    {
        LoginResult login(string userName, string password);
        bool ResetPassword(string email, string oldPassword, string newPassword);
        bool ForgetPassword(string email);
        bool ActivateEmail(string code);
        bool Check(string name, string password);
        JwtResult GenerateToken(string userName, string password);
    }
}