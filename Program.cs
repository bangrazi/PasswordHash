using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(PasswordHash));
            string input;
            Console.WriteLine("Enter a password:");
            while(!string.IsNullOrWhiteSpace(input = Console.ReadLine())) {
                Console.WriteLine($"input={input}");

                string s1 = FromString(input);
                Console.WriteLine($"{nameof(FromString)}={s1}");

                using(Stream s = new MemoryStream(Encoding.ASCII.GetBytes(input))) {
                    string s2 = FromStream(s);
                    Console.WriteLine($"{nameof(FromStream)}={s2}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter a password:");
            }
        }

        static string FromString(string s) {
            using(HashAlgorithm provider = new SHA256CryptoServiceProvider()) {
                provider.ComputeHash(Encoding.ASCII.GetBytes(s));
                return Convert.ToBase64String(provider.Hash);
            }
        }

        static string FromStream(Stream s) {
            using(HashAlgorithm provider = new SHA256CryptoServiceProvider()) {
                provider.ComputeHash(s);
                return Convert.ToBase64String(provider.Hash);
            }
        }
    }
}
