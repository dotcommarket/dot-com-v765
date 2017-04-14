using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sough.Models;

namespace Sough.Controllers
{
    public class CategorieController : BaseController
    {
        //
        // GET: /Categorie/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeLanguage(string lang)
        {
            GererLang.currentLang = lang;
            new GererLang().setLang(lang);
            return RedirectToAction("Create", "Voiture");
        }
    }
}
