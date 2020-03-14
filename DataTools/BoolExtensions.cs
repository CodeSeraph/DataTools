using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTools
{
    public static class BoolExtensions
    {
        public static string ConvertToYN(this bool value)
        {
            if (value)
                return "Y";
            else
                return "N";
        }
        public static string ConvertToYesNo(this bool value)
        {
            if (value)
                return "Yes";
            else
                return "No";
        }
    }
}
