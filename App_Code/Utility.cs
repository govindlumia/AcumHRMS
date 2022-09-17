using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Utilities
{
    public sealed class Utility
    {
        private Utility() { }

        ///<summary>Default Format mm/dd/yyyy,Default Delimination '/', Format 1 'dd/mm/yyyy' </summary> 


        public static DateTime dataformat(string date)
        {
            try
            {
                string[] datesplit = date.Split('/');
                //string[] datesplit = date.Split('-');
                DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }

        public static DateTime DateTimeForat(string date)
        {
            try
            {

                string[] datesplit = date.Split('-');
                int getMonth = DateTime.Parse(datesplit[0] + datesplit[1] + datesplit[2]).Month;
                DateTime dateFormat = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(getMonth), Convert.ToInt32(datesplit[0]));
                return dateFormat;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }

        private int ConvertMonth(string mon)
        {

            try
            {
                switch (mon)
                {
                    case "Jan":
                        return 1;
                    case "Feb":
                        return 2;
                    case "Mar":
                        return 3;
                    case "Apr":
                        return 4;
                    case "May":
                        return 5;
                    case "Jun":
                        return 6;
                    case "Jul":
                        return 7;
                    case "Aug":
                        return 8;
                    case "Sep":
                        return 9;
                    case "Oct":
                        return 10;
                    case "Nov":
                        return 11;
                    case "Dec":
                        return 12;
                    default:
                        return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }
        public static DateTime dataformat(string date, char delim)
        {
            try
            {
                string[] datesplit = date.Split(delim);
                DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }

        public static DateTime dataformat(string date, char delim, int format)
        {
            try
            {
                string[] datesplit = date.Split(delim);
                DateTime dates = new DateTime();
                if (format == 1)
                {
                    dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                }
                else if (format == 2)
                {
                    dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[1]), Convert.ToInt32(datesplit[0]));
                }
                return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }

        public static DateTime indiantime()
        {
            try
            {
                DateTime date = new DateTime();
                date = System.DateTime.UtcNow.AddMinutes(330);
                return date;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in converting" + ex.Message);
            }
        }
        public static DateTime returndatetime(DateTime dt)
        {
            try
            {

                DateTime date = new DateTime();
                date = dt.AddMinutes(300);
                return date;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in converting" + ex.Message);
            }
        }

        public static string Getrandomtext()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
