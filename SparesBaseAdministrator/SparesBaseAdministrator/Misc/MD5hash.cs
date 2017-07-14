using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SparesBaseAdministrator
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

        // Вычисление хеша файла по его пути
        public static string GetMD5FileChecksum(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }

        // Проверка хеша
        public static bool VerifyMD5FileChecksum(string path, string hash)
        {
            string checksumOfFile = GetMD5FileChecksum(path);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(checksumOfFile, hash) == 0)
                return true;
            else
                return false;
        }
    }
}
