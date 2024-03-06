using System.Security.Cryptography;
using System.Text;

namespace DI_Example.Crypto
{
    public class SHA512Encoder: IEncoder
    {
        public string Encode(string data)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = sha.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        public string GetAlgorithmName()
        {
            return "SHA";
        }
    }
}
