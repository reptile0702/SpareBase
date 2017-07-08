using System;
using System.Text;
using System.Security.Cryptography;

namespace SparesBase
{
    class MD5hash
    {
        // Получение хеша
        public static string GetMD5Hash(string input)
        {
            MD5 hash = MD5.Create();
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)          
                builder.Append(data[i].ToString("x2"));

            hash.Clear();
            return builder.ToString();
        }

        // Проверка хеша
        public static bool VerifyMD5Hash(string input, string hash)
        {
            string hashOfInput = GetMD5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(hashOfInput, hash) == 0)
                return true;
            else
                return false;
        }
    }
}
