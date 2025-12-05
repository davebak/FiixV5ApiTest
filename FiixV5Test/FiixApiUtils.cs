using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace FiixV5Test;

public class FiixApiUtils
{
    public static string GenerateAuthSignature(string tenant, string apiKey, string accessKey, string secretKey)
    {
        string message = $"{tenant}.macmms.com/api/?service=cmms&appKey={apiKey}&accessKey={accessKey}&signatureMethod=HmacSHA256&signatureVersion=1";
        byte[] msgBytes = Encoding.UTF8.GetBytes(message);
        byte[] secretBytes = Encoding.UTF8.GetBytes(secretKey);

        // Create an HMACSHA256 instance with the key
        using (HMACSHA256 hmac = new HMACSHA256(secretBytes))
        {
            // Compute the hash of the message
            byte[] hashBytes = hmac.ComputeHash(msgBytes);

            // Convert the byte array to a lowercase hexadecimal string
            return Convert.ToHexString(hashBytes).ToLowerInvariant();
        }
    }
}

