using System.Security.Cryptography;
using System.Text;

namespace DI_Example.Crypto
{
    // MD5Encoder - имплементация кодированяи согласно алгоритму хэширования MD5
    public class MD5Encoder : IEncoder
    {
        public string Encode(string data)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        public string GetAlgorithmName()
        {
            return "MD5";
        }
    }
}
