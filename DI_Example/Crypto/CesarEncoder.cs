using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace DI_Example.Crypto
{
    // CesarEncoder - шифр Цезаря
    public class CesarEncoder : IEncoder
    {
        private const string ALPH = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly int _offset;

        public CesarEncoder(int offset)
        {
            _offset = offset;
        }

        public string Encode(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symb in data)
            {
                int symbIndex = ALPH.IndexOf(symb);
                if (symbIndex != -1)
                {
                    sb.Append(ALPH[(symbIndex + _offset) % ALPH.Length]);
                } else
                {
                    sb.Append(symb);
                }
            }
            return sb.ToString();
        }

        public string GetAlgorithmName()
        {
            return $"Cesar`s cipher (offset={_offset})";
        }
    }
}
