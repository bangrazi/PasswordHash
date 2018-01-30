using System;
using System.Security.Cryptography;
using System.Text;

namespace LicensingPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Licensing Password");
            string input;
            while(!String.IsNullOrWhiteSpace(input = Console.ReadLine())) {
                Console.WriteLine();
                Console.WriteLine($"input={input}");
                using (SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider())
                {
                    provider.ComputeHash(Encoding.ASCII.GetBytes(input));
                    string password = Convert.ToBase64String(provider.Hash);
                    Console.WriteLine($"password={password}");
                }
            }
        }
    }
}
