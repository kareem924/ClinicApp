using Abstract.Service;
using Framework.Models.Result;

namespace Application.SecurityService
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool ActivateEmail(string code)
        {
            throw new System.NotImplementedException();
        }

        public bool ForgetPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        public LoginResult login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool ResetPassword(string email, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }
    }
}