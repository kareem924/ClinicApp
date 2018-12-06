namespace Framework.Models.Result
{
    public class LoginResult
    {
        public bool IsAuhtentaced { get; set; }
        public string Message { get; set; }
        public JwtResult Token { get; set; }
       

    }
}