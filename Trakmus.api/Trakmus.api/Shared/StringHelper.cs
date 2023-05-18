using Microsoft.CodeAnalysis;
using System;
using System.Security.Cryptography;
using System.Text;
using Trakmus.api.DAL;

namespace Trakmus.api.Shared
{
    public static class StringHelper
    {
        /// <summary>
        /// MD5-hashing of string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 

        //Stringarray = [fueltype][sprog]

        private static string[,] fuelTypes = new string[5,2] {
            { "Diesel", "Diesel" },
            { "Benzin", "Gasolin" },
            { "Petrolium", "Kerosene" },
            { "Gas", "Gas" },
            { "TVO", "TVO" }};

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

        public static FuelType ToFuelType (this string fuelName)
        {
            switch (fuelName.ToUpper())
            {
                case "DIESEL":
                    return FuelType.Diesel;
                case "BENZIN":
                    return FuelType.Gasolin;
                case "PETROLIUM":
                    return FuelType.Kerosene;
                case "TVO":
                    return FuelType.TVO;
                default:
                    return FuelType.Diesel;
            }
        }

        public static string ToString(this FuelType fuel, language lang)
        {
            return fuelTypes[((int)fuel),(int)lang];
        }
    }
}
