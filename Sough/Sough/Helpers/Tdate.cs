using Sough.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Threading;
namespace Sough.Helpers
{
    public class Tdate
    {
        /* Save Date in model */
        public void SaveDate<T>(ref T w) where T : Ware
        {
            DateTime dt = DateTime.Now;
            w.temps = dt;
        }


        public string FormaterDate(DateTime dt, string format)
        {
            try
            {
                DateTime dateValue = dt;
                string FormatDate = "";
                string _date = "";

                if (dateValue.Year == DateTime.Now.Year)
                {
                    if (dateValue.Month == DateTime.Now.Month)
                    {
                        if (dateValue.Day == DateTime.Now.Day)
                        {
                            if (format.Equals("fr"))
                                return "Aujourd\'hui, " + dateValue.ToString("hh:mm");
                            else
                                return "اليوم, " + dateValue.ToString("hh:mm");
                        }
                        if (IsYesterday(dateValue))
                        {
                            if (format.Equals("fr"))
                                return "Hier, " + dateValue.ToString("hh:mm");
                            else
                                return "أمس, " + dateValue.ToString("hh:mm");
                        }
                        else
                            FormatDate = "dd MMMM, hh:mm";
                    }
                    else
                        FormatDate = "dd MMMM, hh:mm";
                }
                else
                    FormatDate = "dd MMMM, hh:mm";

                _date = dateValue.ToString(FormatDate);
                if (format.Equals("ar"))
                    return ReplaceFrMonths(_date);
                else
                    return _date;
            }
            catch (Exception e)
            {
                return "";
            }
        }


        public bool IsToday(DateTime dt)
        {
            
            if (dt.Date == DateTime.Today)
                return true;
            return false;
        }
        
        public bool IsYesterday(DateTime dt)
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            if (dt >= yesterday && dt < DateTime.Today)
                return true;
            return false;
        }
        
        public bool IsInLastMonth(DateTime dt)
        {
            DateTime lastMonth = DateTime.Today.AddMonths(-1);
            return dt.Month == lastMonth.Month && dt.Year == lastMonth.Year;
        }
        
        public bool IsInLastYear(DateTime dt)
        {
            return dt.Year == DateTime.Now.Year - 1;
        }
        
        private string ReplaceFrMonths(string d)
        {
            string _d = "";
            if (d.Contains("janvier")) _d = d.Replace("janvier", "يناير");
            else if (d.Contains("février")) _d = d.Replace("février", "فبراير");
            else if (d.Contains("mars")) _d = d.Replace("mars", "مارس");
            else if (d.Contains("avril")) _d = d.Replace("avril", "ابريل");
            else if (d.Contains("mai")) _d = d.Replace("mai", "مايو");
            else if (d.Contains("juin")) _d = d.Replace("juin", "يونيو");
            else if (d.Contains("juillet")) _d = d.Replace("juillet", "يوليو");
            else if (d.Contains("août")) _d = d.Replace("août", "اغشت");
            else if (d.Contains("septembre")) _d = d.Replace("septembre", "سبتمبر");
            else if (d.Contains("octobre")) _d = d.Replace("octobre", "اكتوبر");
            else if (d.Contains("novembre")) _d = d.Replace("novembre", "نفمبر");
            else if (d.Contains("décembre")) _d = d.Replace("décembre", "دجمبر");

            return _d;
        }

        public void ChangeCurrentCulture(string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}