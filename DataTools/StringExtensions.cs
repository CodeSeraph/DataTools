using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataTools
{
    public static class StringExtensions
    {
        public static string RoundNumeric(this String value, int decimalplaces)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(value))
                    return String.Format("{0}", Math.Round(decimal.Parse(value), decimalplaces)).Trim();
                else
                    return value;
            }
            catch (Exception)
            {
                return value;
            }
        }
        public static string HtmlEncode(this String value)
        {
            return HttpContext.Current.Server.HtmlEncode(value);
        }
        public static string HtmlDecode(this String value)
        {
            return HttpContext.Current.Server.HtmlDecode(value);
        }
        public static string RemoveSpecialCharacters(this String value)
        {
            value.Replace(",", "");
            value.Replace("$", "");
            value.Replace("\"", "");
            value.Replace("(", "");
            value.Replace(")", "");
            value.Replace("&", "");
            value.Replace("%", "");
            value.Replace("#", "");
            value.Replace("!", "");
            value.Replace("*", "");
            value.Replace("+", "");
            value.Replace("=", "");

            return value;
        }
        public static string HashValue(this String value)
        {
            return hashstring(value);
        }
        #region Hash Value
        private static string GetMd5Hash(MD5 md5Hash, string value)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        private static string hashstring(string value)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, value);
                return hash;
            }
        }
        #endregion
        public static string StandardizeText(this String value)
        {
            var lowerCase = value.ToLower();
            // matches the first sentence of a string, as well as subsequent sentences
            var r = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
            // MatchEvaluator delegate defines replacement of sentence starts to uppercase
            var result = r.Replace(lowerCase, s => s.Value.ToUpper());

            return result;
        }
        public static string Base64Encode(this String plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(this String base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string ShortenText(this String value, int length)
        {
            if (value.Length > length)
                value = value.Substring(0, length) + "...";

            return value;
        }
        public static string RemoveHTMLTags(this String value)
        {
            Regex x = new Regex("(<)(.*?)(>)");
            return x.Replace(value, "");
        }

        public static T ConvertToEnum<T>(this String value)
            where T : struct, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static string ToCurrency(this String value, string currencysymbol)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencySymbol = currencysymbol + " ";
            nfi.CurrencyGroupSeparator = " ";
            nfi.CurrencyNegativePattern = 14;

            return String.Format(nfi, "{0:C}", Math.Round(decimal.Parse(value), 2)).Trim();
        }
        public static string ToCurrency(this String value, string currencysymbol, int decimalplaces)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencySymbol = currencysymbol + " ";
            nfi.CurrencyGroupSeparator = " ";
            nfi.CurrencyNegativePattern = 14;

            return String.Format(nfi, "{0:C}", Math.Round(decimal.Parse(value), decimalplaces)).Trim();
        }
        public static string ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencySymbol = currencysymbol + " ";
            nfi.CurrencyGroupSeparator = groupseperator;
            nfi.CurrencyNegativePattern = 14;

            return String.Format(nfi, "{0:C}", Math.Round(decimal.Parse(value), decimalplaces)).Trim();
        }
        public static string ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator, string decimalseparator)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencySymbol = currencysymbol + " ";
            nfi.CurrencyGroupSeparator = groupseperator;
            nfi.CurrencyNegativePattern = 14;
            nfi.NumberDecimalSeparator = decimalseparator;

            return String.Format(nfi, "{0:C}", Math.Round(decimal.Parse(value), decimalplaces)).Trim();
        }
        public static string ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator, string decimalseparator, int currencynegativepattern)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencySymbol = currencysymbol + " ";
            nfi.CurrencyGroupSeparator = groupseperator;
            nfi.NumberDecimalSeparator = decimalseparator;
            nfi.CurrencyNegativePattern = currencynegativepattern;

            return String.Format(nfi, "{0:C}", Math.Round(decimal.Parse(value), decimalplaces)).Trim();
        }

        public static bool YesNoToBool(this String value)
        {
            if (value.Trim() == "Yes")
                return true;
            else
                return false;
        }
        public static bool YNToBool(this String value)
        {
            if (value == "Y")
                return true;
            else
                return false;
        }

        //0 	($n)
        //1 	-$n
        //2 	$-n
        //3 	$n-
        //4 	(n$)
        //5 	-n$
        //6 	n-$
        //7 	n$-
        //8 	-n $
        //9 	-$ n
        //10 	n $-
        //11 	$ n-
        //12 	$ -n
        //13 	n- $
        //14 	($ n)
        //15 	(n $)
    }
}