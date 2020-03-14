using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataTools
{
    public class Password
    {
        public static string Random()
        {
            string password = String.Empty;
            password += generateComponent("0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ@!&$#");
            password += generateExtraComponent("AB@!&$#CDEFGHJklmnopqrsTUVWXYZ");
            password += generateExtraComponent("@!&$#");

            return password;
        }
        public static string Random(int length)
        {
            return generateComponent("0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ@!&$#", length);
        }

        private static string generateComponent(string value, int length = 6)
        {
            string _allowedChars = value;
            Random randNum = new Random();
            char[] chars = new char[6];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < length; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        private static string generateExtraComponent(string value)
        {
            string _allowedChars = value;
            Random randNum = new Random();
            char[] chars = new char[2];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < 2; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}
