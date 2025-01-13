using System.Security.Cryptography;
using System.Text;

namespace Services.Shared;

public static class UserUtills
{
    public static string Encrypt(this string password)
    {
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}

