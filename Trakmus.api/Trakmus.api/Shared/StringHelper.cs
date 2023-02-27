using Microsoft.CodeAnalysis;
using System;
using System.Security.Cryptography;
using System.Text;


namespace Trakmus.api.Shared
{
    public static class StringHelper
    {
        /// <summary>
        /// MD5-hashing of string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string PasswordHash(this string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = ASCIIEncoding.Default.GetBytes(password);
            byte[] encoded = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));

            return sb.ToString();

        }
    }
}
