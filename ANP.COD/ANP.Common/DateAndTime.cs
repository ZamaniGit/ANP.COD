using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using ANP.Data;

namespace ANP.Common
{
    public static class DateAndTime
    {

        public static string GetDate8Digit()
        {
            PersianCalendar pcal = new PersianCalendar();
            DateTime curDT = DateTime.Now;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + month + day;
        }

        public static string GetDate8Digit(DateTime dt)
        {
            PersianCalendar pcal = new PersianCalendar();
            DateTime curDT = dt;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + month + day;
        }

        public static string GetDate8Digit_latin()
        {
            GregorianCalendar pcal = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            DateTime curDT = DateTime.Now;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + month + day;
        }

        public static string GetDate8Digit_latin(DateTime dt)
        {
            GregorianCalendar pcal = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            DateTime curDT = dt;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + month + day;
        }

        public static string GetDate10Digit_latin()
        {
            GregorianCalendar pcal = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            DateTime curDT = DateTime.Now;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }

        public static string GetDate10Digit_latin(DateTime dt)
        {
            GregorianCalendar pcal = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            DateTime curDT = dt;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }

        public static string GetDate10Digit()
        {
            PersianCalendar pcal = new PersianCalendar();
            DateTime curDT = DateTime.Now;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }

        public static string GetDate10DigitManyAgoDays(int Days)
        {
            PersianCalendar pcal = new PersianCalendar();
            DateTime curDT = DateTime.Now.AddDays(Days);
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }

        public static string GetDate10Digit(DateTime dt)
        {
            PersianCalendar pcal = new PersianCalendar();
            DateTime curDT = dt;
            string year = pcal.GetYear(curDT).ToString();
            string month = pcal.GetMonth(curDT).ToString();
            string day = pcal.GetDayOfMonth(curDT).ToString();
            day = day.Length == 1 ? "0" + day : day;
            month = month.Length == 1 ? "0" + month : month;
            return year + "/" + month + "/" + day;
        }

        public static string GetDateTime16Digit()
        {
            return GetDate10Digit() + " " + GetTime5Digit();
        }

        public static string GetDateTime16Digit_Latin()
        {
            return GetDate10Digit_latin() + " " + GetTime5Digit();
        }

        public static string GetTime5Digit()
        {
            DateTime curDT = DateTime.Now;
            string hour = curDT.Hour.ToString();
            string minute = curDT.Minute.ToString();
            hour = hour.Length == 1 ? "0" + hour : hour;
            minute = minute.Length == 1 ? "0" + minute : minute;
            return hour + ":" + minute;
        }

        public static string GetTime8Digit()
        {
            DateTime curDT = DateTime.Now;
            string hour = curDT.Hour.ToString();
            string minute = curDT.Minute.ToString();
            string seconds = curDT.Second.ToString();
            hour = hour.Length == 1 ? "0" + hour : hour;
            minute = minute.Length == 1 ? "0" + minute : minute;
            seconds = seconds.Length == 1 ? "0" + seconds : seconds;
            return hour + ":" + minute + ":" + seconds;
        }

        public static string GetSQLDate10DigitShamsi()
        {
            DBConnector dbcon = new DBConnector();
            return dbcon.SqlDataTable("Select dbo.MiladiToShamsi(getdate()) As SqlDate").Rows[0][0].ToString();
        }

        public static string GetSQLDate10DigitMiladi()
        {
            DBConnector dbcon = new DBConnector();
            return dbcon.SqlDataTable("select CAST( GETDATE() as date) ").Rows[0][0].ToString();
        }

        public static string GetSQLDateTimeDigitMiladi()
        {
            DBConnector dbcon = new DBConnector();
            return dbcon.SqlDataTable("Select  cast(getdate() as nvarchar) ").Rows[0][0].ToString();
        }

        public static string GetSQLTime8Digit()
        {
            DBConnector dbcon = new DBConnector();
            string sqlDate = dbcon.SqlDataTable("Select getdate() As SqlDate").Rows[0][0].ToString();
            DateTime curDT = Convert.ToDateTime(sqlDate);
            string hour = curDT.Hour.ToString();
            string minute = curDT.Minute.ToString();
            string seconds = curDT.Second.ToString();
            hour = hour.Length == 1 ? "0" + hour : hour;
            minute = minute.Length == 1 ? "0" + minute : minute;
            seconds = seconds.Length == 1 ? "0" + seconds : seconds;
            return hour + ":" + minute + ":" + seconds;
        }

        public static string PersianDate(string test)
        {
            System.Globalization.PersianCalendar oPersianC = new System.Globalization.PersianCalendar();
            string Day, Month, Year, WeekDays, Date = "";

            if (string.IsNullOrEmpty(test))
            {
                string PersianYear = Year = oPersianC.GetYear(System.DateTime.Now).ToString();
                Month = oPersianC.GetMonth(System.DateTime.Now).ToString();
                Day = oPersianC.GetDayOfMonth(System.DateTime.Now).ToString();
                WeekDays = oPersianC.GetDayOfWeek(System.DateTime.Now).ToString();

                switch (Month)
                {
                    case "1": Month = "فروردین";
                        break;
                    case "2": Month = "اردیبهشت";
                        break;
                    case "3": Month = "خرداد";
                        break;
                    case "4": Month = "تیر";
                        break;
                    case "5": Month = "مرداد";
                        break;
                    case "6": Month = "شهریور";
                        break;
                    case "7": Month = "مهر";
                        break;
                    case "8": Month = "آبان";
                        break;
                    case "9": Month = "آذر";
                        break;
                    case "10": Month = "دی";
                        break;
                    case "11": Month = "بهمن";
                        break;
                    case "12": Month = "اسفند";
                        break;
                    default:
                        break;
                }
                switch (WeekDays)
                {
                    case "Saturday": WeekDays = "شنبه";
                        break;
                    case "Sunday": WeekDays = "یکشنبه";
                        break;
                    case "Monday": WeekDays = "دوشنبه";
                        break;
                    case "Tuesday": WeekDays = "سه شنبه";
                        break;
                    case "Wednesday": WeekDays = "چهار شنبه";
                        break;
                    case "Thursday": WeekDays = "پنج شنبه";
                        break;
                    case "Friday": WeekDays = "جمعه";
                        break;
                }
                Date = "امروز  " + WeekDays + " " + Day + " " + Month + "  سال " + Year;
            }
            else
            {
            }
            return Date;
        }

        public static string MiladiToShamsi(DateTime _Date)
        {

            PersianCalendar pcalendar = new PersianCalendar();
            string Pdate = pcalendar.GetYear(_Date).ToString("0000") + "/" +
               pcalendar.GetMonth(_Date).ToString("00") + "/" +
               pcalendar.GetDayOfMonth(_Date).ToString("00") + " " +
                   pcalendar.GetHour(_Date).ToString("00") + ":" +
                   pcalendar.GetMinute(_Date).ToString("00") + ":" +
                   pcalendar.GetSecond(_Date).ToString("00");

            return Pdate;
        }



        public static DateTime ShamsiToMiladi(string _Date)
        {
            System.String[] userDateParts = _Date.Split(new[] { "/" }, System.StringSplitOptions.None);
            int userYear = int.Parse(userDateParts[0]);
            int userMonth = int.Parse(userDateParts[1]);
            int userDay = int.Parse(userDateParts[2]);
            DateTime fdate = new DateTime(userYear, userMonth, userDay);
            //DateTime fdate = Convert.ToDateTime(_Date);
            GregorianCalendar gcalendar = new GregorianCalendar();
            PersianCalendar pcalendar = new PersianCalendar();
            DateTime eDate = pcalendar.ToDateTime(
                   gcalendar.GetYear(fdate),
                   gcalendar.GetMonth(fdate),
                   gcalendar.GetDayOfMonth(fdate),
                   gcalendar.GetHour(fdate),
                   gcalendar.GetMinute(fdate),
                   gcalendar.GetSecond(fdate), 0);
            return eDate;
        }

        public static double DiffDateShamsi (string _FDate , string _LDate)
        {
            double Result = 0;
            try
            {
                System.TimeSpan timespan = (DateAndTime.ShamsiToMiladi(_LDate) - DateAndTime.ShamsiToMiladi(_FDate));
                Result = timespan.TotalDays;
                return Result;
            }
            catch {
                return -1;
            }
        }
    }


}
