using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class Extentions
    {
        public static int? toInt(this string i)
        {
            return Convert.ToInt32(i);
        }
        public static string toMonthString(this string i)
        {
            switch (i)
            {

                case "01":
                    return "فروردین";
                case "02":
                    return "اردیبهشت";
                case "03":
                    return "خرداد";
                case "04":
                    return "تیر";
                case "05":
                    return "مرداد";
                case "06":
                    return "شهریور";
                case "07":
                    return "مهر";
                case "08":
                    return "آبان";
                case "09":
                    return "آذر";
                case "10":
                    return "دی";
                case "11":
                    return "بهمن";
                case "12":
                    return "اسفند";
                default:
                    return "";
            }
        }

    }
}
