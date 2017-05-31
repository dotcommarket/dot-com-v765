using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Sough
{
    public class GererLang
    {
        public static string currentLang = "ar";

        public static List<Langages> LangagesSite = new List<Langages>
        {
            new Langages{
                langNomComplet = "العربية",
                langNomCourt   = "ar"
            },
            new Langages{
                langNomComplet = "Français",
                langNomCourt   = "fr"
            }
        };

        public static bool IsLangAvailable(string lang)
        {
            return LangagesSite.Where(a => a.langNomCourt.Equals(lang)).
                FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return LangagesSite[1].langNomCourt;
        }

        public void setLang(string lang)
        {
            try
            {
                if (!IsLangAvailable(lang))
                    lang = GetDefaultLanguage();

                var cultureInfo = new CultureInfo(lang);

                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
                
            }
            catch(Exception e)
            {

            }
        }

    }

    public class Langages
    {
        public string langNomComplet { set; get; }
        public string langNomCourt { set; get; }
    }
}