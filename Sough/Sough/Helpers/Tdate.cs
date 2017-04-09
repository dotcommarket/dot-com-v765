using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sough.Helpers
{
    public class Tdate
    {

        public string FormaterDate(DateTime dt, string format)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(format); //ar-EG            
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
                                return "Aujourd\'hui, " + dateValue.ToString("hh:MM", culture);
                            else
                                return "اليوم, " + dateValue.ToString("hh:MM", culture);
                        }
                        if (IsYesterday(dateValue))
                        {
                            if (format.Equals("fr"))
                                return "Hier, " + dateValue.ToString("hh:MM", culture);
                            else
                                return "أمس, " + dateValue.ToString("hh:MM", culture);
                        }
                        else
                            FormatDate = "dd MMMM, hh:MM";
                    }
                    else
                        FormatDate = "dd MMMM, hh:MM";
                }
                else
                    FormatDate = "dd MMMM, hh:MM";

                _date = dateValue.ToString(FormatDate, culture);

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
    }
}