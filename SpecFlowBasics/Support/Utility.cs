using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Support
{
    public class Utility
    {
        public static string GetRandomString(int length)
        {
            var r = new Random();
            return new String(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }

        public int GetRandomInteger()
        {
            Random rnd = new Random();

            for (int j = 0; j < 1; j++)
            {
                Console.WriteLine(rnd.Next());
            }
            return rnd.Next();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

       


    }
}

