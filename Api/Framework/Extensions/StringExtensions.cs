using System.Security.Cryptography;
using System.Text;

namespace Framework.Extensions
{
    public static class StringExtensions
    {
        public static string ToMD5Hash(this string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}