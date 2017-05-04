using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sough.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index" + GererLang.currentLang);
        }

        public ActionResult Indexar() 
        {
            if (GererLang.currentLang.Equals("ar")){
                new GererLang().setLang("ar");
                return View();
            }
            else
                return RedirectToAction("Indexfr");
        }

        public ActionResult Indexfr()
        {
            if (GererLang.currentLang.Equals("fr")){
                new GererLang().setLang("fr");
                return View();
            }
            else
                return RedirectToAction("Indexar");
        }

        public ActionResult ChangeLanguage(string lang)
        {
            GererLang.currentLang = lang;
            new GererLang().setLang(lang);
            return RedirectToAction("Create", "Voiture");
        }
    }
}
