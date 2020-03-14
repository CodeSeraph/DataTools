using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools
{
    public static class Numeric
    {
        public static decimal Percentage(string numerator, string denominator)
        {
            if (numerator == null || numerator == "")
                numerator = "0";

            if (denominator == null || denominator == "")
                denominator = "0";

            try
            {
                decimal oldprice = decimal.Parse(denominator);
                decimal newprice = decimal.Parse(numerator);
                decimal difference = oldprice - newprice;
                decimal saving = (difference / oldprice) * 100;
                return saving;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal Percentage(double numerator, double denominator)
        {
            try
            {
                double difference = denominator - numerator;
                decimal saving = ((decimal)difference / (decimal)denominator) * 100;
                return saving;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal Percentage(decimal numerator, decimal denominator)
        {
            try
            {
                decimal difference = denominator - numerator;
                decimal saving = (difference / denominator) * 100;
                return saving;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal Percentage(int numerator, int denominator)
        {
            try
            {
                decimal difference = denominator - numerator;
                decimal saving = (difference / denominator) * 100;
                return saving;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string ConvertZeroToDash(this double value)
        {
            if (value == 0)
                return "-";
            else
                return value.ToString();
        }
        public static string ConvertZeroToDash(this decimal value)
        {
            if (value == 0)
                return "-";
            else
                return value.ToString();
        }
        public static string ConvertZeroToDash(this int value)
        {
            if (value == 0)
                return "-";
            else
                return value.ToString();
        }
        public static string ConvertZeroToDash(this String value)
        {
            if (value == "0")
                return "-";
            else
                return value;
        }
    }
}
