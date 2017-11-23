using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Public
{
    public class MyCommon
    {
        public static string SESSION_KEY_USER = "KGJT-KGJ4-54KI";
        public static string SESSION_KEY_USERID = "KGJT-KFJ4-54KI";
        public static string SESSION_KEY_ListErrorFileImport = "KGJT-KZJ4-54KI";

        public static bool IsDecimal(string number)
        {
            try
            {
                decimal.Parse(number);
                return true;
            }
            catch { return false; }
        }

        public static bool IsInt(string number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch { return false; }
        }

        public static bool IsFloat(string number)
        {
            try
            {
                float.Parse(number);
                return true;
            }
            catch { return false; }
        }

        public static bool IsDouble(string number)
        {
            try
            {
                double.Parse(number);
                return true;
            }
            catch { return false; }
        }
    }
}
